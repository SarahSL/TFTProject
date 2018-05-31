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
        gameTime = 180.0f;
        gamePlayingState = FindObjectOfType<GameManagerPlaying>();
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        if( gameTime > 0)
        {
            gameTime -= Time.deltaTime;
        }
        else
        {
            gamePlayingState.GPS_GoToInactive();
            m_target.SMG_GoToPoints();
        }
    }
}
