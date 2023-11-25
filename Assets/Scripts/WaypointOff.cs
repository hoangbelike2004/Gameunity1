using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointOff : MonoBehaviour
{
    [SerializeField] private GameObject[] Off;
    [SerializeField] private float speed = 2.5f;
    private int indexLength = 0;
    [SerializeField] private SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Off[indexLength].transform.position,transform.position) < .1f)
        {
            indexLength++;
            if(indexLength >= Off.Length)
            {
                indexLength = 0;
            }
        }
         transform.position=Vector2.MoveTowards(transform.position, Off[indexLength].transform.position,
            Time.deltaTime * speed);

        if (Vector2.Distance(Off[0].transform.position, transform.position) < .1f)
        {
            spr.flipX = true;
        }
        else if (Vector2.Distance(Off[1].transform.position, transform.position) < .1f)
        {
            spr.flipX = false;
        }
    }
}
