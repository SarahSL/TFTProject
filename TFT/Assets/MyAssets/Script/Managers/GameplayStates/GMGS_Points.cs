using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMGS_Points : GMGS_GameplayControllerStates
{
    public PrincipalARController principalARController;
    public InputManager inputManager;
    public GameManagerMain gameManagerMain;
    public override void Enter()
    {
        //SHOW THE POINTS
        principalARController = FindObjectOfType<PrincipalARController>();
        inputManager = FindObjectOfType<InputManager>();
        inputManager.TouchAction += MenuState;
        gameManagerMain = FindObjectOfType<GameManagerMain>();
    }

    public override void Exit()
    {
        inputManager.TouchAction -= MenuState;

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
