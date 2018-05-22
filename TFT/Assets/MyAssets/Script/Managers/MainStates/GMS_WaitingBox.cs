using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GMS_WaitingBox : GMS_ControllerState
{
    public PrincipalARController principalARController;

    public override void Enter()
    {
        principalARController = FindObjectOfType<PrincipalARController>();
        PlayableDirector m_director = principalARController.boxObject.GetComponent<PlayableDirector>();
        m_director.initialTime = 0;
        m_director.Play();
    }

    public override void Exit()
    {
        m_target.SM_GoToMenu();
    }

    public override void Update()
    {

        Debug.Log("HERE WE ARE__ : WaitingBox.Update-------"); 
    }

}
