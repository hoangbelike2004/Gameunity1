using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float speed = 5f;
    public float JumpHeight = 0f;

    SpriteRenderer spr;
    Animator animator;
    private BoxCollider2D col;
    public bool canDash = true;
    public bool Dashing;
    public float Dashtime = 0.5f;
    private float DashCoolDown = 1f;
    [SerializeField] private float dashVelocity;
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
    }

    // Update is called once per frame
    private void Update()
    {
        move = Input.GetAxis("Horizontal");
        if (!Dashing)//check proviso when dashing then method Move() not called
        {
            Move();//when dashing then method move don''t run
        }
       
        StateAnimUpdate();
        if(Input.GetKey(KeyCode.UpArrow))
        {
            Jump();
            
        }
        if(Input.GetKey(KeyCode.Space) && canDash)
        {
            Debug.Log("An");
            StartCoroutine(Effects());
        }
        if (Dashing)
        {
            return;
        }

    }
  
    void Move()
    {
        
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

    private IEnumerator Effects()
    {
        canDash = false;
        Dashing = true;
        if(rb.velocity.x > 0f)
        {
            rb.velocity = new Vector2(move * 15f, rb.velocity.y);
            spr.flipX = false;
            animator.SetInteger("State", 2);
        }
        if (rb.velocity.x < 0f)
        {
            rb.velocity = new Vector2( move * 15f, rb.velocity.y);
            spr.flipX = true;
            animator.SetInteger("State", 2);
        }
        else if (rb.velocity.x == 0f&&spr.flipX == false)
        {
            rb.velocity = new Vector2(move + 15f, rb.velocity.y); animator.SetInteger("State", 2);
        }
        else if (rb.velocity.x == 0f && spr.flipX == true)//player stand still and dash
        {
            rb.velocity = new Vector2(-Mathf.Abs(move + 15f), rb.velocity.y); animator.SetInteger("State", 2);
        }
        Debug.Log("Luot");
        tr.emitting = true;
        yield return new WaitForSeconds(Dashtime);//time dasing
        tr.emitting = false;//turn on effect TrailRenderer
        Dashing=false;//after dash time then not dasing
        Debug.Log("Dung");
       yield return new WaitForSeconds(DashCoolDown);
        canDash = true;//can dash affter 1 second
    }
    
}
