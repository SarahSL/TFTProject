using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMGS_Playing : GMGS_GameplayControllerStates
{
   

    private float gameTime;
    public GameManagerPlaying gamePlayingState;
    public TruckAgent[] truckAgents;
    public WarehouseAgent[] warehouseAgents;
    public PoolTruckController poolTruck;

    public override void Enter()
    {
        //INICIARLIZAR TODO
        warehouseAgents = FindObjectsOfType<WarehouseAgent>();
        foreach (WarehouseAgent warehouseAgent in warehouseAgents)
        {
            warehouseAgent.SM_GoToWaiting();
        }

        gamePlayingState = FindObjectOfType<GameManagerPlaying>();
        poolTruck = FindObjectOfType<PoolTruckController>();
        poolTruck.CreateFirstTruckController();

        gamePlayingState.poolTruck = poolTruck;

        truckAgents = FindObjectsOfType<TruckAgent>();
        foreach (TruckAgent truckagent in truckAgents)
        {
            truckagent.SM_GoToWaiting();
        }
        gameTime = 20.0f;
        gamePlayingState.GPS_GoToPlaying_Waiting();
    }

    public override void Exit()
    {
        truckAgents = FindObjectsOfType<TruckAgent>();
        foreach (TruckAgent truckagent in truckAgents)
        {
            truckagent.SM_GoToInactive();
        }
        warehouseAgents = FindObjectsOfType<WarehouseAgent>();
        foreach (WarehouseAgent warehouseAgent in warehouseAgents)
        {
            warehouseAgent.SM_GoToInactive();
        }
        m_target.principalARController.boardObject.SetActive(false);
    }

    public override void Update()
    {
        if( gameTime > 0)
        {
            gameTime -= Time.deltaTime;
        }
        else
        {
            gamePlayingState.GPS_GoToInactive();
            m_target.SMG_GoToPoints();
        }
    }
}
