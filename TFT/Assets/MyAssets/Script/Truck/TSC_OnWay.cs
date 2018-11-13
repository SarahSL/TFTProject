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
        Debug.Log("ON WAYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY----------");
        capacity = m_target.warehouseSelected.actualCapacity + m_target.load;

        Debug.Log("CAPACITY = = "+capacity+"LOAD TARGET"+m_target.load + "TOTAL CAPACHITY"+ m_target.warehouseSelected.capacity);
        typesLoadWarehouse = m_target.warehouseSelected.typesLoad;
        if(capacity <= m_target.warehouseSelected.capacity)
        {
            for (int aux = 0; aux < typesLoadWarehouse.Length; aux++)
            {
                if (m_target.typeLoad == typesLoadWarehouse[aux])
                {
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
         //   m_target.warehouseSelected.SM_GoToSelected();
            
        }
       else
        {
            m_target.SM_GoToWaiting();
        }
       
    }
}
