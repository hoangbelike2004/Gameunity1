using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class ReplaceSkinAim : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject NinjaMan;
    public GameObject GuyMan;
    public GameObject PinkMan;
    public GameObject MaskDude;

    
    // Update is called once per frame
    IEnumerator Start()
    {
        StartCoroutine(CreateObject());
        yield return null;
    }
   IEnumerator CreateObject()
    {
        if(ReplaceSkin.ReplaceSkins.SkinNR == 0)
        {
            GuyMan.SetActive(true);
        }
        else if (ReplaceSkin.ReplaceSkins.SkinNR == 1)
        {
            PinkMan.SetActive(true);
        }
         else if (ReplaceSkin.ReplaceSkins.SkinNR == 2)
        {
            NinjaMan.SetActive(true);
        }
        else if (ReplaceSkin.ReplaceSkins.SkinNR == 3)
        {
            MaskDude.SetActive(true);
        }
        yield return null;
    }
}
