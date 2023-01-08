using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Harvester : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void LookAtPlayer(Player player)
    {
        bool isLookingRight = player.transform.position.x > transform.position.x;
        animator.SetBool("lookingRight", isLookingRight);
    }

    [YarnCommand("TurnIntoAngel")]
    public void TurnIntoAngel()
    {
        animator.SetTrigger("angel");
    }
}
