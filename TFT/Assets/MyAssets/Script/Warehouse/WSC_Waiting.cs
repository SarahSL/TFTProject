using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSC_Waiting : WSC_WarehouseStateController
{
    private float timeForUnload;
    public override void Enter()
    {
        timeForUnload = 10.0f;

    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        if (timeForUnload < 0)
        {
            if (m_target.actualCapacity> 0)
            {
                m_target.actualCapacity -= m_target.actualCapacity / 2;
                m_target.actualCapacity += m_target.loadTruck;
                m_target.actualCapacityText.text = m_target.actualCapacity + "/" + m_target.capacity;
            }
            timeForUnload = 10.0f;
        }
        timeForUnload -= Time.deltaTime;
    }
}
