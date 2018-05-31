using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GMGS_CountDown : GMGS_GameplayControllerStates
{
    public PrincipalARController principalArCore;
    private GameObject countDownCanvas;
    private Text countDownText;
    private float timeLeft;

    public override void Enter()
    {
        principalArCore = FindObjectOfType<PrincipalARController>();
        countDownText = principalArCore.boardObject.GetComponent<Text>();
        countDownCanvas = principalArCore.boardObject.GetComponent<Canvas>().gameObject;
        countDownCanvas.SetActive(true);
        timeLeft = 3.0f;

    }

    public override void Exit()
    {
        countDownCanvas.SetActive(false);

    }

    public override void Update()
    {
        if (timeLeft < 0)
        {
            m_target.SMG_GoToPlaying();
        }
        if (timeLeft < 1)
        {
            countDownText.text = "1";
        }
        if (timeLeft < 2)
        {
            countDownText.text = "2";
        }
        timeLeft -= Time.deltaTime;

    }
}
