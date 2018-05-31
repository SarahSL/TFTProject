using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GMGS_InitGame : GMGS_GameplayControllerStates
{
    public PrincipalARController principalARController;
    private bool playing = false;
    public PlayableDirector m_director;

    private GameObject countDownCanvas;

    public override void Enter()
    {
        principalARController = FindObjectOfType<PrincipalARController>();

        countDownCanvas = principalARController.boardObject.GetComponentInChildren<Canvas>().gameObject;
        countDownCanvas.SetActive(false);
        principalARController.boardObject.SetActive(true);
        principalARController.boardObject.SetActive(true);
        m_director = principalARController.boardObject.GetComponent<PlayableDirector>();
        m_director.initialTime = 0;
        m_director.Play();

    }

    public override void Exit()
    {
        countDownCanvas.SetActive(true);
    }

    public override void Update()
    {
        if (m_director.state != PlayState.Playing)
        {
            m_target.SMG_GoToCountDown();
        }
    }
}
