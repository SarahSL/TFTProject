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

    public override void Enter()
    {
        // boxObject = FindObjectOfType<PrincipalARController>().boxObject;
        // menuGameObject = boxObject
        inputManager = FindObjectOfType<InputManager>();
        principalARController = FindObjectOfType<PrincipalARController>();


    }

    public override void Exit()
    {
        principalARController.boxObject.SetActive(false);
    }

    public override void Update()
    {
    }

    private void MenuState(Vector2 hit)
    {
        RaycastHit h;

        if (Physics.Raycast(principalARController.m_references.FirstPersonCamera.ScreenPointToRay(hit), out h))
        {
            string pos = h.collider.tag;
            if (pos == "Video")
            {
                m_target.SM_GoToVideo();
            }
            else if (pos == "Game")
            {
                m_target.SM_GoToPlaying();
            }

        }

    }
    void OnEnable()
    {
        inputManager.TouchAction += MenuState;
    }
    void OnDisable()
    {
        inputManager.TouchAction += MenuState;
    }

}
