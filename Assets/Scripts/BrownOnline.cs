using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownOnline : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask Pla;
    [SerializeField] private GameObject Pos;
    private BoxCollider2D coll;
    private int tmp;
    
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (ColliderCheck())
        {
            tmp = 1;
        }
        if(tmp == 1)
        {
            Move();
        }
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, Pos.transform.position, speed * Time.deltaTime);
    }
    private bool ColliderCheck()
    {
        return Physics2D.BoxCast(coll.bounds.center, new Vector2(4.2f, 10), 0, Vector2.zero, 0f, Pla);
    }
}
