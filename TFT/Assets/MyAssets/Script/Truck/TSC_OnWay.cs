using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TSC_OnWay : TSC_TruckControllerState
{
    private bool isPermited = false;
    private float capacity;
    private int[] typesLoadWarehouse;

    public override void Enter()
    {
        capacity = m_target.warehouseSelected.actualCapacity + m_target.load;
        typesLoadWarehouse = m_target.warehouseSelected.typesLoad;
        if(capacity <= m_target.warehouseSelected.capacity)
        {
            for (int aux = 0; aux < typesLoadWarehouse.Length; aux++)
            {
                if (m_target.typeLoad == typesLoadWarehouse[aux])
                {
                    m_target.warehouseSelected.loadTruck = m_target.load;
                    isPermited = true;
                }
            }
        }
            
            
    }

    public override void Exit()
    {
        isPermited = false;
    }

    public override void Update()
    {
        if (isPermited)
        {
            m_target.agent.destination = m_target.warehouseSelected.transform.position;
            
            m_target.gameManagerPlaying.NewTruck(m_target.positionTruck);

            m_target.warehouseSelected.SM_GoToSelected();
            m_target.SM_GoToInactive();
        }
       else
        {
            m_target.SM_GoToWaiting();
        }
       
    }
}
