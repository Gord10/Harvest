using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
public class Room : MonoBehaviour
{
    public string startNode;
    public float waitTime = 0;
    public enum PlayerMovementMode
    {
        ONLY_X,
        Y_AND_SCROLLING_X,
        NO_MOVEMENT
    }

    public PlayerMovementMode playerMovementMode = PlayerMovementMode.Y_AND_SCROLLING_X;

    private DialogueRunner dialogRunner;
    protected virtual void Awake()
    {
        dialogRunner = FindObjectOfType<DialogueRunner>();
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        if(startNode != null)
        {
            yield return new WaitForSeconds(waitTime);
            while (!dialogRunner)
            {
                yield return new WaitForEndOfFrame();
            }

            while(!dialogRunner.yarnProject)
            {
                print("No yarn project!");
            }

            while (!dialogRunner.NodeExists(startNode))
            {
                yield return new WaitForEndOfFrame();
            }
            dialogRunner.StartDialogue(startNode);
        }

    }
}
