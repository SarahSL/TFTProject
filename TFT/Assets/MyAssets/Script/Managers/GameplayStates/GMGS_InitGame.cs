using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GMGS_InitGame : GMGS_GameplayControllerStates
{
    public PrincipalARController principalARController;
    private bool playing = false;
    public PlayableDirector m_director;

    public override void Enter()
    {
        principalARController = FindObjectOfType<PrincipalARController>();
        playing = false;

        principalARController.boardObject.SetActive(true);

    }

    public override void Exit()
    {
       
    }

    public override void Update()
    {
        if(!playing)
        {
            m_director = principalARController.boardObject.GetComponent<PlayableDirector>();
            m_director.initialTime = 0;
            m_director.Play();
        }
        else
        {
            if (m_director.state != PlayState.Playing)
            {
                m_target.SMG_GoToCountDown();
            }
        }
    }
}
