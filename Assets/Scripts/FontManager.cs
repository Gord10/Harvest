using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FontManager : MonoBehaviour
{
    public TMP_FontAsset englishAndTurkishFont;
    public TMP_FontAsset ukranianFont;

    private void Awake()
    {
        TextMeshProUGUI[] texts = FindObjectsOfType<TextMeshProUGUI>(true);

        int i;
        for(i = 0; i < texts.Length; i++)
        {
            if(GameManager.Language == "uk")
            {
                texts[i].font = ukranianFont;
                texts[i].fontSize *= 1.6666f;
            }
            else
            {
                texts[i].font = englishAndTurkishFont;
            }
        }
    }
}
