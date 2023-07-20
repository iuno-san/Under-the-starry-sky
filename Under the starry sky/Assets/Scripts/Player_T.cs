using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_T : MonoBehaviour
{
    [Header("Main")]

    [SerializeField] private float MovmentSpeed;
    [SerializeField] private float JumpHeight;

    Rigidbody2D rigidbody2d;

    float horizontal;
    float spacekey;

    bool isgrounded;

    [Header("Other")]

    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private Transform GroundCheck;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        spacekey = Input.GetAxis("Jump");
    }

    private void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(horizontal * MovmentSpeed, rigidbody2d.velocity.y);

        isgrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);

        if (spacekey != 0 && isgrounded)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, JumpHeight * spacekey);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GroundCheck.position, 0.2f);
    }
}
