using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private DialogueRunner dialogRunner;
    private Player player;
    private FadeScreen fadeScreen;

    private void Awake()
    {
        dialogRunner = FindObjectOfType<DialogueRunner>();
        player = FindObjectOfType<Player>();
        fadeScreen = FindObjectOfType<FadeScreen>();
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
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    [YarnCommand("FadeOut")]
    public void FadeOut()
    {
        fadeScreen.GetShown();
    }

    public IEnumerator OnPlayerEnterPark()
    {
        FadeOut();
        yield return new WaitForSeconds(2);
        LoadScene("Park");
    }
}
