using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;


    [SerializeField] private AudioSource jumpSoundEffect;
    private bool canJump = true; // Biến cờ cho phép nhảy

    // Start is called before the first frame update
    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && canJump)
        {
            Jump();
        }

        UpdateAnimationUpdate();
    }

    private void Jump()
    {
        jumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        canJump = false; // Đặt cờ nhảy thành false sau khi nhảy
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Untagged"))
        {
            canJump = true; // Đặt lại cờ nhảy thành true khi nhân vật tiếp xúc với mặt đất
        }
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;

        if (dirX != 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = dirX < 0f;
            state = MovementState.running;
        }
        else
        {
            anim.SetBool("running", false);
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private enum MovementState { idle, running, jump, falling }
}

