using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GMGS_Playing : GMGS_GameplayControllerStates
{
   

    private float gameTime;
    private Text gameTimeText;

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


        m_target.GameTimeUI.SetActive(true);
        gameTimeText = m_target.GameTimeUI.GetComponentInChildren<Text>();
        gameTime = 60.0f;
        gameTimeText.text = "Tiempo: " + " " + gameTime.ToString("f0");
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
        m_target.GameTimeUI.SetActive(false);
        m_target.principalARController.boardObject.SetActive(false);
    }

    public override void Update()
    {
        if( gameTime > 0)
        {
            gameTime -= Time.deltaTime;

            gameTimeText.text = "Tiempo:" + " " + gameTime.ToString("f0");

        }
        else
        {
            gameManagerPlaying.GPS_GoToInactive();
            m_target.SMG_GoToPoints();
        }
    }
}
