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
    private bool canDash = true;
    private bool Dashing;
    private float DashPower=24f;
    private float Dashtime = 0.2f;
    private float DashCoolDown = 1f;
    private float tmp;

    [SerializeField] private TrailRenderer tr;
    [SerializeField] private LayerMask GR;
    private enum ValuesAnim { idle,runing,jumping,falling}
    private float move;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
        spr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        tr = GetComponent<TrailRenderer>();   
    }

    // Update is called once per frame
    private void Update()
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
        StartCoroutine(Dash());

    }
    void Jump()
    {
        if (isPlay())
        {
            Debug.Log("jump");
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
            StartCoroutine(Dash());
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

    private IEnumerator Dash()
    {
        canDash = false;
        Dashing = true;
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow)) {
            tr.emitting = true;
        }
        else { tr.emitting = false; }
        yield return null;
        
    }
    
}
