using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerController : MonoBehaviour
{

    [SerializeField] private GameObject PlayerPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerPos.transform.position.x,PlayerPos.transform.position.y,-10);
    }
}
