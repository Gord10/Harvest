using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Yarn.Unity;

public class Title : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI pressAnyKey;

    private void Awake()
    {
        if(GameManager.Language == "tr")
        {
            title.text = "BİR HASAT HİKAYESİ";
            pressAnyKey.text = "Devam etmek için herhangi bir tuşa basın...";
        }
        else if(GameManager.Language == "uk")
        {
            title.text = "Розповідь про жнива";
            pressAnyKey.text = "Натисніть будь - яку клавішу щоб продовжити...";
        }

        pressAnyKey.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > 1)
        {
            pressAnyKey.enabled = ((int)(Time.timeSinceLevelLoad * 2f)) % 2 == 0;

            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("StreetIntro");
            }
        }

#if UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif
    }
}
