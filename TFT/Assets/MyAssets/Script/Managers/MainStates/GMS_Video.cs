
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GMS_Video : GMS_ControllerState
{
    public PrincipalARController principalARController;
    private bool playing = false;
    public PlayableDirector m_director;
    public override void Enter()
    {
        principalARController = FindObjectOfType<PrincipalARController>();
        playing = false;
        principalARController.boxObject.SetActive(false);
        principalARController.videoObject.SetActive(true);
    }

    public override void Exit()
    {
        principalARController.videoObject.SetActive(false);
    }

    public override void Update()
    {
        if (!playing)
        {
            m_director = principalARController.videoObject.GetComponent<PlayableDirector>();
            m_director.initialTime = 0;
            m_director.Play();
        }
        else
        {
            if (m_director.state != PlayState.Playing)
            {
                m_target.SM_GoToWaitingBox();
            }
        }
    }
    
}
