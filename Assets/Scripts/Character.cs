using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [Range(0, 20)] public float speed = 1;
    [Range(0, 20)] public float jump = 1;
    [Range(-20, 20)] public float gravity = -9.8f;
    public Vector3 defaultPos;
    public Animator animator;
    public Weapon weapon;
    public eSpace space = eSpace.WORLD;
    public eMovement movement = eMovement.FREE;
    public float turnRate = 3;


    public enum eSpace
    {
        WORLD,
        CAMERA,
        OBJECT
    }

    public enum eMovement
    {
        FREE,
        TANK,
        STRAFE
    }

    CharacterController characterController;

    Vector3 inputDirection, velocity, moveDir;
    Quaternion defaultRot;
    Transform camTransform;

    bool isGrounded = false;

    Health health;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        health = GetComponent<Health>();

        defaultPos = transform.position;
        defaultRot = transform.rotation;

        camTransform = Camera.main.transform;
    }

    void Update()
    {
        if(Game.Instance != null)
        {
            if(Game.Instance.State == Game.eState.GAME)
            {
                Move();
            }
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = 0;

        //****
        Quaternion orientation = Quaternion.identity;
        switch (space)
        {
            case eSpace.CAMERA:
                Vector3 forward = camTransform.forward;
                forward.y = 0;
                orientation = Quaternion.LookRotation(forward);
                break;
            case eSpace.OBJECT:
                orientation = transform.rotation;
                break;
            default:
                break;
        }

        Vector3 direction = Vector3.zero;
        Quaternion rotation = Quaternion.identity;
        switch (movement)
        {
            case eMovement.FREE:
                direction = orientation * inputDirection;
                rotation = (direction.sqrMagnitude > 0) ? Quaternion.LookRotation(direction) : transform.rotation;
                break;
            case eMovement.TANK:
                direction.z = inputDirection.z;
                direction = orientation * direction;

                rotation = orientation * Quaternion.AngleAxis(inputDirection.x, Vector3.up);
                break;
            case eMovement.STRAFE:
                direction = orientation * inputDirection;
                rotation = Quaternion.LookRotation(orientation * Vector3.forward);
                break;
            default:
                break;
        }


        //Quaternion camRot = Camera.main.transform.rotation;
        //Quaternion rot = Quaternion.AngleAxis(camRot.eulerAngles.y, Vector3.up);
        //Vector3 direction = rot * inputDirection;
        //****

        characterController.Move(direction * Time.deltaTime * speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * turnRate);

        velocity.y += gravity * Time.deltaTime;

        animator.SetFloat("Speed", inputDirection.magnitude);
        animator.SetBool("OnGround", isGrounded);
        animator.SetFloat("VelocityY", velocity.y);

        characterController.Move(velocity * Time.deltaTime);

        if (health.CurrentHealth <= 0)
        {
            animator.SetTrigger("Death");
            Game.Instance.State = Game.eState.GAME_OVER;
        }
    }

    public void ResetGame()
    {
        //Animation
        animator.SetTrigger("Reset");

        //Health
        health.CurrentHealth = health.maxHealth;

        //Transform
        transform.position = defaultPos;
        transform.rotation = defaultRot;
    }

    public void OnDeath()
    {
        animator.SetTrigger("Death");
    }

    public void OnJump()
    {
        if (isGrounded)
        {
            velocity.y += jump;
        }
    }

    public void OnMove(InputValue input)
    {
        Vector2 v2 = input.Get<Vector2>();

        inputDirection.x = v2.x;
        inputDirection.z = v2.y;
    }

    public void OnPunch()
    {
        animator.SetTrigger("Punch");
    }

    public void OnThrow()
    {
        animator.SetTrigger("Throw");
    }

    public void OnFire()
    {
        weapon.Fire(transform.forward);
    }
}
