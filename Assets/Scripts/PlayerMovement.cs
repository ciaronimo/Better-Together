using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    public Animator playerAnim;


    bool hasHorizontalMovement = true;
    public bool isJumping;
    public bool isAttacking;
    float jumpTimer = 0f;
    public bool isGrounded;
    private Vector3 initialScale;





    [SerializeField] float moveSpeed = 150f;
    [SerializeField] float jumpPeriod = .25f;
    [SerializeField] float jumpSpeed = 150f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] Vector2 groundBoxSize = new Vector2(0.2f, 0.5f);



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerAnim = GetComponent<Animator>();
        initialScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundBoxSize, groundLayer);
        float hAxis = Input.GetAxisRaw("Horizontal");
        //if the player isn't moving, stop the player from moving in the x
        //this is important because it stops the character from moving when the player stops x-axis input
        if (hAxis == 0)
        {
            hasHorizontalMovement = false;
        }
        else if (hAxis != 0)
        {
            hasHorizontalMovement = true;
        }



        HorizontalMove(hAxis);
        Jump();

        if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D)))
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A)))
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }




        playerAnim.SetFloat("speed", Mathf.Abs(hAxis));
        playerAnim.SetBool("isGrounded", isGrounded);
        playerAnim.SetBool("isJumping", isJumping);


        HorizontalMove(hAxis);
        Jump();

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

        if (Input.GetButtonDown("Jump") && isGrounded)

        if (Input.GetButtonDown("Jump"))

        {

            isJumping = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jumpTimer = jumpPeriod;
            isJumping = false;
        }

        if (isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
            }
            Debug.Log("@");
            jumpTimer = 0f;
        }


        if (Input.GetButton("Jump") && isGrounded)

        if (Input.GetButton("Jump"))

        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer < jumpPeriod)
            {
                rb.AddForce(new Vector2(0, jumpSpeed * Time.deltaTime), ForceMode2D.Impulse);

            }
        }
        playerAnim.SetBool("isJumping", isJumping);
    }



    }

    //animator.SetBool("isJumping", isJumping);



