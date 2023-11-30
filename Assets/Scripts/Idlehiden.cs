using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idlehiden : MonoBehaviour
{
    private BoxCollider2D coll;
    [SerializeField] private LayerMask pla;
    [SerializeField] private GameObject idle;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckBox())
        {
            idle.SetActive(true);
        }
    }
    private bool CheckBox()
    {
         return Physics2D.BoxCast(coll.bounds.center, new Vector2(4,2), 0,Vector2.zero,.1f,pla);
    }
}
