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

    public Animator animator;

    CharacterController characterController;

    Vector3 inputDirection, velocity, moveDir;

    bool isGrounded = false;

    Health health;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        health = GetComponent<Health>();
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = 0;

        Quaternion camRot = Camera.main.transform.rotation;
        Quaternion rot = Quaternion.AngleAxis(camRot.eulerAngles.y, Vector3.up);
        Vector3 direction = rot * inputDirection;

        characterController.Move(direction * Time.deltaTime * speed);

        if(inputDirection.magnitude > 0.1f)
        {
            Quaternion target = Quaternion.LookRotation(direction.normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * speed);
        }

        velocity.y += gravity * Time.deltaTime;

        animator.SetFloat("Speed", inputDirection.magnitude);
        animator.SetBool("OnGround", isGrounded);
        animator.SetFloat("VelocityY", velocity.y);

        characterController.Move(velocity * Time.deltaTime);

        if(health.CurrentHealth <= 0)
        {
            animator.SetTrigger("Death");
        }
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
        print("fhklsd");
    }
}
