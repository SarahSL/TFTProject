using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GMGS_InitGame : GMGS_GameplayControllerStates
{
    public override void Enter()
    {
        m_target.principalARController.boardObject.SetActive(true);
        m_target.SMG_GoToCountDown();
    }
    public override void Exit()
    {
    }
    public override void Update()
    {
        
    }
}
