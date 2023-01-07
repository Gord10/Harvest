using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    private DialogueRunner dialogRunner;

    private void Awake()
    {
        dialogRunner = FindObjectOfType<DialogueRunner>();
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
}
