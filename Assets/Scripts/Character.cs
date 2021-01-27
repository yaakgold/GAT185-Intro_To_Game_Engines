using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [Range(0, 20)] public float speed = 1;
    [Range(0, 20)] public float jump = 1;
    [Range(-20, 20)] public float gravity = -9.8f;

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

        if(inputDirection.magnitude > 0.1f)
        {
            transform.forward = inputDirection.normalized;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += jump;
        }

        if(!isGrounded)
            velocity.y += gravity * Time.deltaTime;

        moveDir = (inputDirection * speed * Time.deltaTime) + velocity;

        characterController.Move(moveDir);


    }
}
