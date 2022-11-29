using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private const float MIN_DISTANCE = 0.001f;

    public float maxWalkSpeed;
    public float jumpSpeed;

    public bool isWalking = false;
    public bool isJumping = false;
    public bool isRunning = false;
    public bool isCrouching = false;

    private bool _isFlipped = false;

    Vector3 playerVelocity;

    void Start()
    {
        playerVelocity = Vector3.zero;
    }

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        playerVelocity.x = direction * maxWalkSpeed;

        if (Mathf.Abs(direction) > MIN_DISTANCE && !isJumping && !isCrouching)
            isWalking = true;
        else
            isWalking = false;        
        anim.SetBool("isWalking", isWalking);

        if (direction < 0 && !_isFlipped)
            FlipPlayer();
        if (direction > 0 && _isFlipped)
            FlipPlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            playerVelocity.y = jumpSpeed;
        }
        else
        {
            playerVelocity.y = GetComponent<Rigidbody2D>().velocity.y;
        }

        GetComponent<Rigidbody2D>().velocity = playerVelocity;
    }


    void FlipPlayer()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        _isFlipped = !_isFlipped;
    }

}
