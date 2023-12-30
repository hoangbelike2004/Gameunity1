using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerController : MonoBehaviour
{

    [SerializeField] private GameObject PlayerPos;
    [SerializeField] private GameObject NinjaManPos;
    [SerializeField] private GameObject PinkManPos;
    [SerializeField] private GameObject MaskDudePos;



    // Update is called once per frame
    void Update()
    {
        
        if (ReplaceSkin.ReplaceSkins.SkinNR == 0)
        {
            transform.position = new Vector3(PlayerPos.transform.position.x, PlayerPos.transform.position.y, -10);
        }
        else if (ReplaceSkin.ReplaceSkins.SkinNR == 1)
        {
            transform.position = new Vector3(PinkManPos.transform.position.x, PinkManPos.transform.position.y, -10);
        }
        else if (ReplaceSkin.ReplaceSkins.SkinNR == 2)
        {
            transform.position = new Vector3(NinjaManPos.transform.position.x, NinjaManPos.transform.position.y, -10);
        }
        else if (ReplaceSkin.ReplaceSkins.SkinNR == 3)
        {
            transform.position = new Vector3(MaskDudePos.transform.position.x, MaskDudePos.transform.position.y, -10);
        }
    }
}
