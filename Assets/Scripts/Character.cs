using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [Range(0, 20)] public float speed = 1;
    [Range(0, 20)] public float jump = 1;
    [Range(-20, 20)] public float gravity = -9.8f;

    public Animator animator;

    CharacterController characterController;

    Vector3 inputDirection, velocity, moveDir;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
            velocity.y = 0;

        inputDirection = Vector3.zero;

        inputDirection.x = Input.GetAxis("Horizontal");
        inputDirection.z = Input.GetAxis("Vertical");

        Quaternion camRot = Camera.main.transform.rotation;
        Quaternion rot = Quaternion.AngleAxis(camRot.eulerAngles.y, Vector3.up);
        Vector3 direction = rot * inputDirection;

        if(inputDirection.magnitude > 0.1f)
        {
            Quaternion target = Quaternion.LookRotation(direction.normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * speed);
        }

        animator.SetFloat("Speed", inputDirection.magnitude);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += jump * Time.deltaTime;
        }

        velocity.y += gravity * Time.deltaTime;

        moveDir = (direction * speed * Time.deltaTime) + velocity;

        characterController.Move(moveDir);


    }
}
