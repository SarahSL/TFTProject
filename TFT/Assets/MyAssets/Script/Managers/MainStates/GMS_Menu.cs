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
    private bool playing = false;
    public override void Enter()
    {
        // boxObject = FindObjectOfType<PrincipalARController>().boxObject;
        // menuGameObject = boxObject
        playing = false;
        principalARController = FindObjectOfType<PrincipalARController>();
    }

    public override void Exit()
    {

        Debug.Log("HERE WE ARE__ : Menu.Exit-------");
    }

    public override void Update()
    {
        Debug.Log("HERE WE ARE__ : Menu.Update-------");
        if (!playing)
        {
            RaycastHit h;
            if (Physics.Raycast(principalARController.m_references.FirstPersonCamera.ScreenPointToRay(Input.GetTouch(0).position), out h))
            {
                string pos = h.collider.tag;
                if (pos == "Video")
                {
                    principalARController.boxObject.SetActive(false);
                    principalARController.videoObject.SetActive(true);
                    m_director = principalARController.videoObject.GetComponent<PlayableDirector>();
                    m_director.initialTime = 0;
                    m_director.Play();
                    playing = true;
                }
                else if (pos == "Game")
                {
                    principalARController.boxObject.SetActive(false);
                }

            }

        }
        else
        {
            if (m_director.state != PlayState.Playing)
            {
                principalARController.videoObject.SetActive(false);
                m_target.SM_GoToWaitingBox();
            }
        }

    }
}
