using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerController : MonoBehaviour
{

    [SerializeField] private GameObject PlayerPos;

   

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerPos.transform.position.x,PlayerPos.transform.position.y,-10);
    }
}
