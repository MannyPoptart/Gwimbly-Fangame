using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isGrounded;
    private bool isJumping;
    private bool isFalling;
    private bool isMoving;

    private CharacterController character;
    private Animator animator;

    public float speed = 5f;
    public float jumpForce = 7f;
    public float gravity = 10f;
    
    Vector3 move = Vector3.zero;
    

    void Start() {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
    }

    void Update() {

        Movement();
        HandleAnimations();

        // Debug line to see how far the character is from the ground
        // Debug.DrawRay(transform.position, Vector3.down * 1.1f, Color.red);

    }

    private void Movement() {
        // Check if the character is grounded using a raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.08f);

        Vector3 horizontalMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        horizontalMove = transform.TransformDirection(horizontalMove);
        horizontalMove *= speed;

        if (isGrounded) {

            if (Input.GetButtonDown("Jump")) {
                move.y = jumpForce;
                isJumping = true;
                isFalling = false;
            } else {
                isJumping = false;
                isFalling = false;
                move.y = 0f;  // Reset vertical velocity when grounded
            }

        } else {
            move.y -= gravity * Time.deltaTime;  // Apply gravity over time
            isFalling = true;
        }

        if (horizontalMove.x != 0 || horizontalMove.z != 0) {
            isMoving = true;
        } else {
            isMoving = false;
        }

        character.Move((horizontalMove + new Vector3(0, move.y, 0)) * Time.deltaTime);
    }




    private void HandleAnimations() {
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isFalling", isFalling);
        animator.SetBool("isMoving", isMoving);
    }

}
