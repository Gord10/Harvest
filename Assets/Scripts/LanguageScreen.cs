using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LanguageScreen : MonoBehaviour
{
    public void MakeEnglish()
    {
        GameManager.SetLanguage("en-US");
    }

    public void MakeTurkish()
    {
        GameManager.SetLanguage("tr");
    }

    public void MakeUkranian()
    {
        GameManager.SetLanguage("uk");
    }

    public void StartTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void StartCredits()
    {
        SceneManager.LoadScene("GameEnd");
    }
}
