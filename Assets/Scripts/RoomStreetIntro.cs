using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStreetIntro : Room
{
    private GameManager gameManager;
    protected override void Awake()
    {
        base.Awake();
        gameManager = FindObjectOfType<GameManager>();
        gameManager.FadeOut();
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            gameManager.FadeIn();
        }
    }
}
