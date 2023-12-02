using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    public float JumpHeight = 0f;
    private bool Grounded = false;
    SpriteRenderer spr;
    Animator animator;
    private BoxCollider2D col;
    [SerializeField] private LayerMask GR;
    private enum ValuesAnim { idle,runing,jumping,falling}
    private float move;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
        spr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        StateAnimUpdate();
        if(Input.GetKey(KeyCode.UpArrow))
        {
            Jump();
            
        }
    }
    void Move()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }
    void Jump()
    {
        if (isPlay())
        {
            Debug.Log("jump");
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
            AudioManager.audio.PlaySound(AudioManager.audio.AcJump, 1f);

        }

    }
   private bool isPlay()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, Vector2.down, .1f, GR);
    }
    private void StateAnimUpdate()
    {
        ValuesAnim state;
        if (move < 0f)
        {
            spr.flipX = true;
            state = ValuesAnim.runing;
        }
        else if (move > 0f)
        {
            spr.flipX = false;
            state = ValuesAnim.runing;
        }
        else
        {
            state = ValuesAnim.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = ValuesAnim.jumping;
            
        }
        else if(rb.velocity.y < -.1f)
        {
            state = ValuesAnim.falling;
        }
        animator.SetInteger("State",(int)state);
    }
    
}
