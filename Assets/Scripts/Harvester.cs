using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
