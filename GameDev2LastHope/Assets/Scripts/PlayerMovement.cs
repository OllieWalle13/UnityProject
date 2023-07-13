using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite; // crispy
    private Animator anim;
    private float strawberries;

    private ItemCollector itemCollector;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float moveSpeed = 7f;
    private bool hasDoubleJumped = false;

    private enum MovementState {idle, running, jumping, falling, doubleJump}

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Start");
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        itemCollector = GetComponent<ItemCollector>();
    }

    // Update is called once per frame
    void Update()
    {
        strawberries = itemCollector.getStrawberry();
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (dirX != 0 && Input.GetKey(KeyCode.LeftShift) && strawberries > 0)
        {
            if (strawberries > 0)
            {
                rb.velocity = new Vector2(dirX * (moveSpeed + strawberries), rb.velocity.y);
            }
        }

        if (IsGrounded())
        {
            hasDoubleJumped = false;
        }
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(0,jumpForce);
        } else if (Input.GetButtonDown("Jump") && !IsGrounded() && !hasDoubleJumped && itemCollector.getKiwi()) {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(0, jumpForce);
            hasDoubleJumped = true;
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState() {

        MovementState state;

        if (dirX > 0f) {
            state = MovementState.running;
            sprite.flipX = false;
        } else if (dirX < 0f) {
            state = MovementState.running;
            sprite.flipX = true;
        } else {
            state = MovementState.idle;
        }

        if (hasDoubleJumped && rb.velocity.y > .1f) {
            state = MovementState.doubleJump;
        } else if (rb.velocity.y > .1f) {
            state = MovementState.jumping;
        } else if (rb.velocity.y < -.1f) {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
