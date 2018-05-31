using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMS_OpenBox : GMS_ControllerState
{
    private GMS_Menu menu;
    public PrincipalARController principalARController;
    public override void Enter()
    {
        principalARController = FindObjectOfType<PrincipalARController>();
        Debug.Log("HERE WE ARE__ : OpenBox.Enter-------");
        menu = FindObjectOfType<GMS_Menu>();
    }

    public override void Exit()
    {
        principalARController.boxObject.SetActive(false);
    }

    public override void Update()
    {
        // ¿ EN EL ENTER ? 
        if (menu.raycastTag == "Video")
        {
            m_target.SM_GoToVideo();
        }
        else if (menu.raycastTag == "Game")
        {
            m_target.SM_GoToPlaying();
        }
    }

}
