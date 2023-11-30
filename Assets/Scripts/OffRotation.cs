using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
