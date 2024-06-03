using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player player;
    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += Vector3.forward * Time.deltaTime * 3;
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position += Vector3.back * Time.deltaTime * 3;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += Vector3.left * Time.deltaTime * 3;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += Vector3.right * Time.deltaTime * 3;
        }

        // if the player is touching the ground, then the player can jump
        if (Input.GetKeyDown(KeyCode.Space) && player.transform.position.y < 1)
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * 2, ForceMode.Impulse);
        } // if the player holds the space key, the player can jump higher
        else if (Input.GetKey(KeyCode.Space) && player.transform.position.y < 1)
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * 0.1f, ForceMode.Impulse);
        }


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
