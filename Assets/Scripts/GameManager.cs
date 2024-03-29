using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string Language = "en-US";

    private DialogueRunner dialogRunner;
    private AudioLineProvider lineProvider;
    private Player player;
    private FadeScreen fadeScreen;

    private void Awake()
    {
        dialogRunner = FindObjectOfType<DialogueRunner>();
        player = FindObjectOfType<Player>();
        fadeScreen = FindObjectOfType<FadeScreen>();

        lineProvider = FindObjectOfType<AudioLineProvider>();
        lineProvider.textLanguageCode = Language;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogRunner.IsDialogueRunning && Input.anyKeyDown)
        {
            dialogRunner.OnViewRequestedInterrupt();
        }

#if UNITY_STANDALONE
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif
    }

    public bool IsPlayerMovementAllowed()
    {
        return !dialogRunner.IsDialogueRunning;
    }

    public void OnPlayerReachHarvester(Harvester harvester)
    {
        harvester.LookAtPlayer(player);
        dialogRunner.StartDialogue("HelloThere");
    }

    [YarnCommand("LoadScene")]
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    [YarnCommand("FadeOut")]
    public void FadeOut()
    {
        if(fadeScreen == null)
        {
            fadeScreen = FindObjectOfType<FadeScreen>();
        }
        fadeScreen.GetShown();
    }

    public IEnumerator OnPlayerEnterPark()
    {
        FadeOut();
        yield return new WaitForSeconds(0.5f);
        LoadScene("Park");
    }

    public void FadeIn()
    {
        if (fadeScreen == null)
        {
            fadeScreen = FindObjectOfType<FadeScreen>();
        }
        fadeScreen.Hide();
    }

    [YarnCommand("SetLanguage")]
    public static void SetLanguage(string languageCode)
    {
        Language = languageCode;
        print(Language);
    }

    [YarnFunction("GetLanguage")]
    public static string GetLanguage()
    {
        return Language;
    }
}
