
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GMS_Video : GMS_ControllerState
{
    public PrincipalARController principalARController;
    public PlayableDirector m_director;

    public override void Enter()
    {
        principalARController = FindObjectOfType<PrincipalARController>();
        principalARController.videoObject.SetActive(true);
        m_director = principalARController.videoObject.GetComponent<PlayableDirector>();
        m_director.initialTime = 0;
        m_director.Play();

    }

    public override void Exit()
    {
        principalARController.videoObject.SetActive(false);
    }

    public override void Update()
    {
        if (m_director.state != PlayState.Playing)
        {
            m_target.SM_GoToWaitingBox();
        }
    }
}
