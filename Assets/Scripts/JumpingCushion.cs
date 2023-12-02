using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpingCushion : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask LayerMaskPlayer;
    [SerializeField] private GameObject Pla;
    [SerializeField] private float Force;//Force of cushion
    private Animator animator;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (IsplayJump())
        {
            animator.SetBool("Cs", true);
            
                    Pla.GetComponent<Rigidbody2D>().velocity = new Vector2(Pla.GetComponent<Rigidbody2D>().velocity.x, Force);
            
        }
        else if(!IsplayJump()&& time > .55f)
        {
            time = 0;
            animator.SetBool("Cs", false);
        }
    }
    private bool IsplayJump()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0,Vector2.up,0.1f,LayerMaskPlayer);
    }
}
