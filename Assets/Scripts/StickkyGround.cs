using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickkyGround : MonoBehaviour
{
    
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") ;
        {
            collision.gameObject.transform.SetParent(transform);//The player will be attached to the ground
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);//collision ends, the player will not be attached to the ground 
        }
    }
}
