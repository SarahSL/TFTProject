using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GMGS_CountDown : GMGS_GameplayControllerStates
{
    private Text countDownText;
    private float timeLeft;

    public override void Enter()
    {
        m_target.CountDownUI.SetActive(true);
        timeLeft = 3.0f;

        countDownText = m_target.CountDownUI.GetComponentInChildren<Text>();

        countDownText.text = "3";

    }

    public override void Exit()
    {
        countDownText.text = "";
        m_target.CountDownUI.SetActive(false);

    }

    public override void Update()
    {
         if (timeLeft < 0)
        {
            countDownText.text = "0";
            m_target.SMG_GoToPlaying();
        }
        else if (timeLeft < 1)
        {
            countDownText.text = "1";
        }
        else if (timeLeft < 2)
        {
            countDownText.text = "2";
        }
        timeLeft -= Time.deltaTime;
        

    }
}
