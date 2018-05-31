using GoogleARCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GMS_Menu : GMS_ControllerState
{
    public GameObject boxObject;
    public GameObject menuGameObject;
    public PrincipalARController principalARController;
    public PlayableDirector m_director;
    public InputManager inputManager;
    public string raycastTag;

    public override void Enter()
    {
        inputManager = FindObjectOfType<InputManager>();
        principalARController = FindObjectOfType<PrincipalARController>();
        raycastTag = "";
        inputManager.TouchAction += MenuState;
    }
    public override void Exit()
    {
        principalARController.boxObject.SetActive(false);

        inputManager.TouchAction -= MenuState;
    }

    public override void Update()
    {

    }

    private void MenuState(Vector2 hit)
    {
        RaycastHit h;
        if (Physics.Raycast(principalARController.m_references.FirstPersonCamera.ScreenPointToRay(hit), out h))
        {
            raycastTag = h.collider.tag;
            if (raycastTag == "Video" || raycastTag == "Game")
            {
                m_target.SM_GoToOpenBox();
            }
        }

    }


}
