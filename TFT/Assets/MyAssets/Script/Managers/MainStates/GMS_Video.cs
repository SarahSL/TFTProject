
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GMS_Video : GMS_ControllerState
{
    public PlayableDirector m_director;

    public override void Enter()
    {
        m_target.principalARController.videoObject.SetActive(true);
        m_director = m_target.principalARController.videoObject.GetComponent<PlayableDirector>();
        m_director.initialTime = 0;
        m_director.Play();
    }
    public override void Exit()
    {
        m_target.principalARController.videoObject.SetActive(false);
    }
    public override void Update()
    {
        if (m_director.state != PlayState.Playing)
        {
            m_target.SM_GoToWaitingBox();
        }
    }
}
