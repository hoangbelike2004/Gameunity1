using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingOstacle : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D coll;
    [SerializeField] private LayerMask pla;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling())
        {
            rb.gravityScale = 2f;
        }
    }
    private bool isFalling()
    {
        return Physics2D.BoxCast(coll.bounds.center, new Vector2(8, 30), 0, Vector2.zero, 0f, pla);
    }
}
