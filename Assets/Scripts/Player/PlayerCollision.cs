using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private CapsuleCollider2D playerCollider;
    [SerializeField] private Vector2 defaultColliderOffset;
    [SerializeField] private Vector2 crouchColliderOffset;
    [SerializeField] private Vector2 defaultColliderSize;
    [SerializeField] private Vector2 crouchColliderSize;

    private bool _changedSize = false;

    void Start()
    {
        playerMovement = PlayerMovement.Instance;
    }

    void Update()
    {
        if (playerMovement.isCrouching && !_changedSize)
        {
            _changedSize = true;
            playerCollider.size = crouchColliderSize;
            playerCollider.offset = crouchColliderOffset;
        }
        if (!playerMovement.isCrouching && _changedSize)
        {
            _changedSize = false;
            playerCollider.size = defaultColliderSize;
            playerCollider.offset = defaultColliderOffset;
        }        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        playerMovement.isHitingGround = true;
        playerMovement.isOnAirJumping = false;
    }
}
