using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
public class Room : MonoBehaviour
{
    public string startNode;

    private DialogueRunner dialogRunner;
    private void Awake()
    {
        dialogRunner = FindObjectOfType<DialogueRunner>();
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        //yield return new WaitForSeconds(1);
        while(!dialogRunner.NodeExists(startNode))
        {
            yield return new WaitForEndOfFrame();
        }
        dialogRunner.StartDialogue(startNode);
    }
}
