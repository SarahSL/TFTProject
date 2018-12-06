using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSC_Selected : WSC_WarehouseStateController
{
    public override void Enter()
    {
        m_target.actualCapacity += m_target.loadTruck;
        m_target.actualCapacityText.text = m_target.actualCapacity + "/" + m_target.capacity;
        m_target.SM_GoToWaiting();
    }
    public override void Exit()
    {
    }
    public override void Update()
    {
    } 
}
