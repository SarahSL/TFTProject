using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMGS_Playing : GMGS_GameplayControllerStates
{
   

    private float gameTime;
    public GameManagerPlaying gameManagerPlaying;
    public TruckAgent[] truckAgents;
    public WarehouseAgent[] warehouseAgents;
    public PoolTruckController poolTruck;

    public override void Enter()
    {
        gameManagerPlaying = FindObjectOfType<GameManagerPlaying>();
        poolTruck = FindObjectOfType<PoolTruckController>();
        poolTruck.CreateFirstTruckController();

        gameManagerPlaying.poolTruck = poolTruck;
        warehouseAgents = FindObjectsOfType<WarehouseAgent>();
        foreach (WarehouseAgent warehouseAgent in warehouseAgents)
        {
            warehouseAgent.SM_GoToWaiting();
        }
        truckAgents = FindObjectsOfType<TruckAgent>();
        foreach (TruckAgent truckagent in truckAgents)
        {
            truckagent.SM_GoToWaiting();
        }

        gameTime = 60.0f;
        gameManagerPlaying.wareLinkText.SetActive(true);

        gameManagerPlaying.GPS_GoToPlaying_Waiting();
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

        gameManagerPlaying.wareLinkText.SetActive(false);
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
            gameManagerPlaying.GPS_GoToInactive();
            m_target.SMG_GoToPoints();
        }
    }
}
