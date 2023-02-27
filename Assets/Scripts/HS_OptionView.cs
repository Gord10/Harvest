using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class HS_OptionView : OptionView
{
    protected override void Awake()
    {
        if(GameManager.GetLanguage() == "uk")
        {
            FontManager fontManager = FindObjectOfType<FontManager>();
            TMP_Text text = GetComponent<TMP_Text>();
            text.font = fontManager.ukranianFont;
            text.fontSize *= 1.6666f;
        }
    }
}
