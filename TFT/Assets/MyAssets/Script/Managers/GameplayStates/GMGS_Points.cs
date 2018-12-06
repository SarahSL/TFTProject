using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GMGS_Points : GMGS_GameplayControllerStates
{
    public InputManager inputManager;
    public GameManagerMain gameManagerMain;
    private GameManagerPlaying gameManagerPlaying;
    private Text points;

    public override void Enter()
    {
        gameManagerPlaying = FindObjectOfType<GameManagerPlaying>();
        m_target.pointsUI.SetActive(true);
        points =  m_target.pointsUI.GetComponentInChildren<Text>();
        points.text += gameManagerPlaying.points;

        inputManager = FindObjectOfType<InputManager>();
        inputManager.TouchAction += MenuState;
        gameManagerMain = FindObjectOfType<GameManagerMain>();
    }
    public override void Exit()
    {
        inputManager.TouchAction -= MenuState;
        m_target.pointsUI.SetActive(false);
    } 
    public override void Update()
    {

    }
    private void MenuState(Vector2 hit)
    {
        Debug.Log("Points");
        m_target.SMG_GoToInactive();
        gameManagerMain.SM_GoToWaitingBox();
    }
}
