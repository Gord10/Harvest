using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Harvester : MonoBehaviour
{
    private Animator animator;
    private AudioSource audio;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    public void LookAtPlayer(Player player)
    {
        bool isLookingRight = player.transform.position.x > transform.position.x;
        animator.SetBool("lookingRight", isLookingRight);
    }

    [YarnCommand("LookLeft")]
    public void LookLeft()
    {
        animator.SetBool("lookingRight", false);
    }

    [YarnCommand("TurnIntoAngel")]
    public void TurnIntoAngel()
    {
        animator.SetTrigger("angel");
        audio.Play();
    }
}
