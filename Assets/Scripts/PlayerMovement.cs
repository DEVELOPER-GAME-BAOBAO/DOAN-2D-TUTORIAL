using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.XR;

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

    private enum MovementState { idle, running, jump, falling }

	[SerializeField] private AudioSource jumpSoundEffect;
    //private MovementState state = MovementState.idle;

    // Start is called before the first frame update
    private void Start()
    {
		coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sprite= GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        //Debug.Log("GAME OVERNIGHT");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
			jumpSoundEffect.Play(); 
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationUpdate();
	}
    private void UpdateAnimationUpdate()
    {
        MovementState state;
		if (dirX > 0f)
		{
			anim.SetBool("running", true);
			sprite.flipX = false;
		}
		else if (dirX < 0f)
		{
			anim.SetBool("running", true);
            sprite.flipX = true;
		}
		else
		{
			anim.SetBool("running", false);
		}
		if (dirX > 0f)
		{
			state = MovementState.running;
			sprite.flipX = false;
		}
		else if (dirX < 0f)
		{
			state= MovementState.running;
			sprite.flipX = true;
		}
		else
		{
			state = MovementState.idle;
		}

		if(rb.velocity.y > .1f)
		{
			state = MovementState.jump;
		}
		else if(rb.velocity.y < -.1f)
		{
			state = MovementState.falling;
		}

		anim.SetInteger("state", (int)state);
	}
	private bool IsGrounded()
	{
		return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
	}
} 
