using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMS_Playing : GMS_ControllerState
{
    public PrincipalARController principalARController;
    public GameManagerGameplay gameMangaerGameplay;
    public override void Enter()
    {
        gameMangaerGameplay = FindObjectOfType<GameManagerGameplay>();
        principalARController = FindObjectOfType<PrincipalARController>();
       
    }

    public override void Exit()
    {
       
    }

    public override void Update()
    {
        m_target.SM_GoToInactive();
        gameMangaerGameplay.SMG_GoToInitGame();
    }
}
