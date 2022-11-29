using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [SerializeField] private Animator anim;

    private const float MIN_DISTANCE = 0.001f;

    public float maxWalkSpeed;
    public float jumpSpeed;

    public bool isWalking = false;
    public bool isOnAirJumping = false;
    public bool isHitingGround = true;
    public bool isRunning = false;
    public bool isCrouching = false;

    private bool _isFlipped = false;

    Vector3 playerVelocity;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        playerVelocity = Vector3.zero;
    }

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        playerVelocity.x = direction * maxWalkSpeed;

        if (Mathf.Abs(direction) > MIN_DISTANCE && !isOnAirJumping && !isCrouching && isHitingGround)
            isWalking = true;
        else
            isWalking = false;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isCrouching = true;
        } else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isCrouching = false;
        }

        if (direction < 0 && !_isFlipped)
            FlipPlayer();
        if (direction > 0 && _isFlipped)
            FlipPlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isCrouching = false;
            isHitingGround = false;
            isOnAirJumping = true;
            playerVelocity.y = jumpSpeed;
        }
        else
        {
            playerVelocity.y = GetComponent<Rigidbody2D>().velocity.y;
        }

        GetComponent<Rigidbody2D>().velocity = playerVelocity;

        UpdateAnimator();
    }

    void UpdateAnimator()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isOnAirJumping", isOnAirJumping);
        anim.SetBool("isHitingGround", isHitingGround);
        anim.SetBool("isCrouching", isCrouching);
    }

    void FlipPlayer()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        _isFlipped = !_isFlipped;
    }

}
