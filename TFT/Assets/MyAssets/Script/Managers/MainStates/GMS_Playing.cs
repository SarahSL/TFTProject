using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMS_Playing : GMS_ControllerState
{
    public GameManagerGameplay gameMangaerGameplay;
    public override void Enter()
    {
        gameMangaerGameplay = FindObjectOfType<GameManagerGameplay>();
       
    }

    public override void Exit()
    {
       
    }

    public override void Update()
    {
        if(gameMangaerGameplay.m_states.m_current == gameMangaerGameplay.m_states.m_inactive)
        {
            gameMangaerGameplay.SMG_GoToInitGame();
        }
            
    }
}
