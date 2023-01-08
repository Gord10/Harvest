using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeScreen : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        //image.enabled = false;
    }

    public void GetShown()
    {
        if(image == null)
        {
            image = GetComponent<Image>();
        }
        image.enabled = true;
    }

    public void Hide()
    {
        image.enabled = false;
    }
}
