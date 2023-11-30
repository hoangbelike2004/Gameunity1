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
    private enum ValuesAnim { idle,runing,jumping,falling}
    private float move;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
        spr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
        if (Grounded)
        {
            Debug.Log("jump");
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
            AudioManager.audio.PlaySound(AudioManager.audio.AcJump, 1f);

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Grounded = true;
            Debug.Log("cham");
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log(" het cham");
            Grounded =false;
        }
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
