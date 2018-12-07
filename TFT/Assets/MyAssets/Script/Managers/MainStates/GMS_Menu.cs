using GoogleARCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GMS_Menu : GMS_ControllerState
{
    public InputManager inputManager;
    public string raycastTag;

    public override void Enter()
    {
        inputManager = FindObjectOfType<InputManager>();
        raycastTag = "";
        inputManager.TouchAction += MenuState;
    }
    public override void Exit()
    {
        m_target.principalARController.boxObject.SetActive(false);

        inputManager.TouchAction -= MenuState;
    }

    public override void Update()
    {

    }

    private void MenuState(Vector2 hit)
    {
        RaycastHit h;
        if (Physics.Raycast(m_target.principalARController.m_references.FirstPersonCamera.ScreenPointToRay(hit), out h))
        {
            raycastTag = h.collider.tag;
            if (raycastTag == "Video" || raycastTag == "Game")
            {
                m_target.SM_GoToOpenBox();
            }
        }

    }


}
