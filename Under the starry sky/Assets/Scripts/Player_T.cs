using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_T : MonoBehaviour
{
    [Header("Main")]

    [SerializeField] private float MovmentSpeed;
    [SerializeField] private float JumpHeight;

    [Space]

    [SerializeField] private Animator FXAnimator;

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
        horizontal = Input.GetAxisRaw("Horizontal");
        spacekey = Input.GetAxis("Jump");

        if (horizontal != 0)
        {
            if (horizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            FXAnimator.SetBool("IsRunning", true);
        }
        else
        {
            FXAnimator.SetBool("IsRunning", false);
        }
    }

    private void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(MovmentSpeed * horizontal, rigidbody2d.velocity.y);

        isgrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);

        if (spacekey != 0 && isgrounded)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, JumpHeight * spacekey);
        }

        if (isgrounded == true)
        {
            FXAnimator.SetBool("IsGrounded", false);
        }
        else
        {
            FXAnimator.SetBool("IsGrounded", true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GroundCheck.position, 0.2f);
    }
}
