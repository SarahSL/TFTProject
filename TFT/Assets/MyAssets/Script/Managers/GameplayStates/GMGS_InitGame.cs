using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GMGS_InitGame : GMGS_GameplayControllerStates
{
    public PlayableDirector m_director;
    

    public override void Enter()
    {
        m_target.principalARController.boardObject.SetActive(true);
        m_director = m_target.principalARController.boardObject.GetComponent<PlayableDirector>();
        m_director.initialTime = 0;
        m_director.Play();

    }

    public override void Exit()
    {
        GameObject.Find("Truckvideo").SetActive(false);

    }

    public override void Update()
    {
        if (m_director.state != PlayState.Playing)
        {
            m_target.SMG_GoToCountDown();
        }
    }
}
