using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [HideInInspector] public bool isPaused = false;

    [SerializeField] private Animator anim;

    private const float MIN_DISTANCE = 0.95f;

    [SerializeField] private float maxWalkSpeed;
    [SerializeField] private float maxCrouchSpeed;
    [SerializeField] private float jumpSpeed;

    private float _maxSpeed;

    [HideInInspector] public bool isWalking = false;
    [HideInInspector] public bool isOnAirJumping = false;
    [HideInInspector] public bool isHitingGround = true;
    [HideInInspector] public bool isRunning = false;
    [HideInInspector] public bool isCrouching = false;

    private bool _isFlipped = false;
    private Rigidbody2D _rb;

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
        _maxSpeed = maxWalkSpeed;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isPaused)
        {
            float x_direction = Input.GetAxisRaw("Horizontal");
            float y_direction = Input.GetAxisRaw("Vertical");

            playerVelocity = Vector3.Normalize(new Vector3(x_direction, y_direction, 0.0f)) * _maxSpeed;

            if ((Mathf.Abs(x_direction) > MIN_DISTANCE || (Mathf.Abs(y_direction) > MIN_DISTANCE)) && !isCrouching && isHitingGround)
            {
                _maxSpeed = maxWalkSpeed;
                isWalking = true;
            }
            else
                isWalking = false;

            if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftShift)) )
            {
                _maxSpeed = maxCrouchSpeed;
                isCrouching = true;
            } else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isCrouching = false;
            }

            if (x_direction < 0 && !_isFlipped)
                FlipPlayer();
            if (x_direction > 0 && _isFlipped)
                FlipPlayer();

            _rb.velocity = playerVelocity;
        }
        else
        {
            _rb.velocity = Vector3.zero;
            isWalking = false; isHitingGround = true; isCrouching = false;
        }
        UpdateAnimator();
    }

    void UpdateAnimator()
    {
        anim.SetBool("isWalking", isWalking);
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
