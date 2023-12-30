using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] Waypoin;
    private int Index = 0;
    [SerializeField]  private float speed = 3f;
    
    private void Update()
    {
        
        if (Vector2.Distance(Waypoin[Index].transform.position, transform.position) < .1f)//check point one in list gameobject to position of ground
        {
            Index++;//check further point two 
            if(Index >= Waypoin.Length)//if that index >= array gameobject then review index = 0 and review to start
            {
                Index = 0;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position,Waypoin[Index].transform.position,Time.deltaTime * speed);//move position ground to positon of point 1 and 2
    }
}
