using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Help code a camera that follows the player side scroller style
    // The camera should follow the player on the x axis
    // The camera should not follow the player on the y axis
    // The camera should not follow the player on the z axis
    // The camera should be 10 units behind the player on the z axis
    // The camera should be 5 units above the player on the y axis
    // The camera should look at the player
    // The camera should not rotate with the player

    [SerializeField]
    private Transform playerTransform;

    private Vector3 offset;

    private void Awake()
    {
        offset = new Vector3(0, 5, -10);
    }

    private void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
        transform.LookAt(playerTransform);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
