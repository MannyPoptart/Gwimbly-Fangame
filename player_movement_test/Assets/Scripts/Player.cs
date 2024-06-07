using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isGrounded;
    private bool isJumping;
    private bool isFalling;
    private bool isMoving;

    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public float gravity = 9.8f;

    private Rigidbody rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0.0f, vertical);
        moveDirection = transform.TransformDirection(moveDirection);

        if (moveDirection != Vector3.zero)
        {
            isMoving = true;
            rb.velocity = moveDirection * speed;
        }
        else
        {
            isMoving = false;
        }

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isJumping = true;
                animator.SetBool("isJumping", true);
                isGrounded = false;
                animator.SetBool("isGrounded", false);
            }
            else
            {
                isJumping = false;
                animator.SetBool("isJumping", false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);
            isFalling = false;
            animator.SetBool("isFalling", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false);
            isFalling = true;
            animator.SetBool("isFalling", true);
        }
    }
}
