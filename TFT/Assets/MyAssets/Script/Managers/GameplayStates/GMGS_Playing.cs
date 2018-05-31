using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMGS_Playing : GMGS_GameplayControllerStates
{
   

    private float gameTime;
    public GameManagerPlaying gamePlayingState;
    public override void Enter()
    {
        //INICIARLIZAR TODO
        gameTime = 20.0f;
        gamePlayingState = FindObjectOfType<GameManagerPlaying>();
        gamePlayingState.GPS_GoToPlaying_Waiting();
    }

    public override void Exit()
    {
        m_target.principalARController.boardObject.SetActive(false);
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
