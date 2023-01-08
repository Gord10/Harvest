using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
public class Room : MonoBehaviour
{
    public string startNode;
    public float waitTime = 0;

    private DialogueRunner dialogRunner;
    private void Awake()
    {
        dialogRunner = FindObjectOfType<DialogueRunner>();
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(waitTime);

        while(!dialogRunner.NodeExists(startNode))
        {
            yield return new WaitForEndOfFrame();
        }
        dialogRunner.StartDialogue(startNode);
    }
}
