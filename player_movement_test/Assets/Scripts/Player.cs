using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Prevent player from rotating on its own
        rb.freezeRotation = true;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
            // Make player face forward
            transform.rotation = Quaternion.LookRotation(Vector3.back);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
            // Make player face backward
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
            // Make player face left
            transform.rotation = Quaternion.LookRotation(Vector3.right);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
            // Make player face right
            transform.rotation = Quaternion.LookRotation(Vector3.left);
        }

        // Apply movement
        transform.position += direction * Time.deltaTime * 3;

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 3, ForceMode.Impulse);  // Adjust the force value as needed
        }

        // To allow higher jumps if space is held down
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 0.1f, ForceMode.Impulse);
        }

        // Keep the player upright
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    private void OnCollisionStay(Collision collision)
    {
        // Check if player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if player left the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
