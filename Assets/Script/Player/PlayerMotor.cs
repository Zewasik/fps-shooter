using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Vector3 playerVelocity;
    private Animator animator;
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input, float isRunning)
    {

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        if (isRunning > 0 && (moveDirection.x != 0 || moveDirection.z <= 0))
        {
            isRunning = 0;
        }

        animator.SetBool("isSprinting", moveDirection.z > 0 && isRunning > 0 && moveDirection.x == 0);
        animator.SetBool("movingForward", moveDirection.z > 0 && isRunning == 0);
        animator.SetBool("movingBackward", moveDirection.z < 0 && isRunning == 0);

        animator.SetBool("movingLeft", moveDirection.x < 0 && moveDirection.z == 0);
        animator.SetBool("movingRight", moveDirection.x > 0 && moveDirection.z == 0);

        controller.Move((speed + isRunning * speed) * Time.deltaTime * transform.TransformDirection(moveDirection));

        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump() 
    {
        if (isGrounded)
        {
            if (animator) animator.SetTrigger("isJumping");
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }
}
