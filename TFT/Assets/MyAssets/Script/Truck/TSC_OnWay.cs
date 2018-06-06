using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TSC_OnWay : TSC_TruckControllerState
{
   // public Transform goal;
   // public GameObject street;
    private bool isPermited;

    public override void Enter()
    {
        Debug.Log("ON WAYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY----------");
        //goal = GameObject.FindGameObjectWithTag("Goal").transform;
        isPermited = true;
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        if (isPermited)
        {
            Debug.Log("ON WAYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY----------");
            m_target.agent.destination = m_target.warehousePosition.position;
            isPermited = false;
        }
       else
        {
            m_target.SM_GoToWaiting();
        }
       
    }
}
