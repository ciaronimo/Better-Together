using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 150f;
    [SerializeField] float jumpPeriod = .25f;
    [SerializeField] float jumpSpeed = 150f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundRadius = .1f;

    Rigidbody2D rb;
    bool hasHorizontalMovement = true;
    float jumpTimer = 0f;
    Animator animator;
    bool isJumping = false;
    bool isWalking = false;
    bool isGrounded = true;
    Vector3 ogScale;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ogScale = transform.localScale; 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        float hAxis = Input.GetAxisRaw("Horizontal");
        //if the player isn't moving, stop the player from moving in the x
        //this is important because it stops the character from moving when the player stops x-axis input
        if (hAxis == 0)
        {
            isWalking = false;
            hasHorizontalMovement = false;
        }
        else if (hAxis != 0)
        {
            isWalking = true;
            hasHorizontalMovement = true;
        }
        HorizontalMove(hAxis);
        Jump();
        FlipSprite(hAxis);
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isJumping", isJumping);
    }

    void HorizontalMove(float hAxis)
    {
        //check if player can move horizontally
        if (hasHorizontalMovement)
        {
            rb.velocity = new Vector2(moveSpeed * hAxis * Time.deltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void Jump()
    {
        Debug.Log(isJumping);
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("justJumped");
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jumpTimer = jumpPeriod;
        }

        if (isGrounded)
        {
            isJumping = false;
            jumpTimer = 0f;
        }

        if (Input.GetButton("Jump"))
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer < jumpPeriod)
            {
                isJumping = true;
                rb.AddForce(new Vector2(0, jumpSpeed * Time.deltaTime), ForceMode2D.Impulse);
            }
        }
    }



    void FlipSprite(float hAxis)
    {
        if (hAxis < 0) transform.localScale = new Vector3(ogScale.x * -1, ogScale.y, ogScale.z);
        else if (hAxis > 0) transform.localScale = new Vector3(ogScale.x, ogScale.y, ogScale.z);
    }
}
