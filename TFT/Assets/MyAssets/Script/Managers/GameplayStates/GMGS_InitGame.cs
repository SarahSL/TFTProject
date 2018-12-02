using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GMGS_InitGame : GMGS_GameplayControllerStates
{
    public PlayableDirector m_director;

    public GameManagerPlaying gamePlayingState;
    public TruckAgent[] truckAgents;
    public WarehouseAgent[] warehouseAgents;
    public PoolTruckController poolTruck;


    public override void Enter()
    {
        m_target.principalARController.boardObject.SetActive(true);
    }

    public override void Exit()
    {

    }

    public override void Update()
    {

        m_target.SMG_GoToCountDown();
    }
}
