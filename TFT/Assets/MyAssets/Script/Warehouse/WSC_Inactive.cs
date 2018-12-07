using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSC_Inactive : WSC_WarehouseStateController
{
    public override void Enter()
    {
        m_target.actualCapacity = 0;
        m_target.actualCapacityText.text = m_target.actualCapacity + "/" + m_target.capacity;
    }
    public override void Exit()
    {
    }
    public override void Update()
    {
    }
}
