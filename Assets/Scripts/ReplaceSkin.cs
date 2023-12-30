using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceSkin : MonoBehaviour
{
    public static ReplaceSkin ReplaceSkins;
    public int SkinNR = 0;
    public Skins[] skin;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    private void Awake()
    {
        ReplaceSkins = this;
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        ChoiceSkin();
    }
    public void RightSkin()
    {
        SkinNR++;
        if(SkinNR > skin.Length - 1)
        {
            SkinNR = 0;
        }
    }
    public void LeftSkin()
    {
        SkinNR--;
        if (SkinNR < 0)
        {
            SkinNR = skin.Length - 1;
        }
    }
    public void ChoiceSkin()
    {
        if (spriteRenderer.sprite.name.Contains("Run"))
        {
            string NameSkin = spriteRenderer.sprite.name;
            NameSkin = NameSkin.Replace("Run (32x32)_", "");
            int spriteNR = int.Parse(NameSkin);

            spriteRenderer.sprite = skin[SkinNR].sprites[spriteNR];
        }
    }
}
[System.Serializable]
public struct Skins
{
    public Sprite[] sprites;
}
