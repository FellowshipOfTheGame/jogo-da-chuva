using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxWalkSpeed;
    public float jumpSpeed;

    Vector3 playerVelocity;

    void Start()
    {
        playerVelocity = Vector3.zero;
    }

    void Update()
    {
        playerVelocity.x = Input.GetAxis("Horizontal") * maxWalkSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerVelocity.y = jumpSpeed;
        }
        else
        {
            playerVelocity.y = GetComponent<Rigidbody2D>().velocity.y;
        }

        GetComponent<Rigidbody2D>().velocity = playerVelocity;
    }

}
