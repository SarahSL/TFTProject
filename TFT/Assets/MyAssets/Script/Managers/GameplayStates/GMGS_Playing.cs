using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMGS_Playing : GMGS_GameplayControllerStates
{
    public PrincipalARController principalARController;
   

    private float gameTime;
    public GameManagerPlaying gamePlayingState;
    public override void Enter()
    {
        //INICIARLIZAR TODO
        principalARController = FindObjectOfType<PrincipalARController>();
        gameTime = 20.0f;
        gamePlayingState = FindObjectOfType<GameManagerPlaying>();
    }

    public override void Exit()
    {
        principalARController.boardObject.SetActive(false);
    }

    public override void Update()
    {
        if( gameTime > 0)
        {
            gameTime -= Time.deltaTime;
            Debug.Log(gameTime);
        }
        else
        {
            gamePlayingState.GPS_GoToInactive();
            m_target.SMG_GoToPoints();
        }
    }
}
