using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundcheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    private Animator animator;

    public int extraJumpValue = 1;
    private int extraJump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        extraJump = extraJumpValue;
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (isGrounded) 
        {
            extraJump = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
            else if (extraJump > 0) 
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                extraJump--;
            }
        }

        SetAnimation(moveInput);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, groundLayer);
    }

    private void SetAnimation(float moveInput)
    {
        if (isGrounded) 
        {
            if (moveInput == 0)
            {
                animator.Play("player_idle");
            }
            else 
            {
                animator.Play("player_run");
            }
        } else if(rb.linearVelocityY < 0)
        {
            animator.Play("player_jump");
        }
        else
        {
            animator.Play("player_fall");
        }
    }
}
