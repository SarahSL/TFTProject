using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSC_Waiting : TSC_TruckControllerState
{


    public override void Enter()
    {
        Debug.Log("TRUCK STATE WAITING");
        m_target.SM_GoToAngry();
    }

    public override void Exit()
    {
        Debug.Log("TRUCK STATE EXIT WAITING");
    }
    

    public override void Update()
    {
    }
}
