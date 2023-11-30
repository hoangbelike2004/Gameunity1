using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] private LayerMask pla;
    private BoxCollider2D coll;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (isPlay())
        {
            AudioManager.audio.PlaySound(AudioManager.audio.AcWin, 1f);
            if(time > 2.01f)
            {
                time = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private bool isPlay()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0,Vector2.left,0.1f,pla);
    }
    
}
