using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddCoin : MonoBehaviour
{
    private int coinID = 0;
    [SerializeField] private TextMeshProUGUI textM;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            coinID++;
            textM.text = "Melon: " + coinID;
            AudioManager.audio.PlaySound(AudioManager.audio.AcaetingCoin, 1f);
        }
    }
}
