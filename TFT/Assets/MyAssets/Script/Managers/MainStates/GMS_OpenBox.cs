using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMS_OpenBox : GMS_ControllerState
{
    private GMS_Menu menu;
    public override void Enter()
    {
        menu = FindObjectOfType<GMS_Menu>();

        if (menu.raycastTag == "Video")
        {
            m_target.SM_GoToVideo();
        }
        else if (menu.raycastTag == "Game")
        {
            m_target.SM_GoToPlaying();
        }
    }
    public override void Exit()
    {
    }
    public override void Update()
    {
    }

}
