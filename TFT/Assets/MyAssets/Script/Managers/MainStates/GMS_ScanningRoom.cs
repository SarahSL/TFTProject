using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;
using UnityEngine.AI;
using GoogleARCore.PrincipalAR;
public class GMS_ScanningRoom : GMS_ControllerState
{
    public GameObject principalARControllerObject;
    private List<TrackedPlane> m_NewPlanes = new List<TrackedPlane>();
    private List<TrackedPlane> m_AllPlanes = new List<TrackedPlane>();
    private bool m_IsQuitting = false;
    private bool placed = false;
    
    public override void Enter()
    {
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        placed = m_target.principalARController.placed;
        if (!placed)
        {
            m_target.principalARController.Scan();
        }
        else
        {
            m_target.SM_GoToWaitingBox();
        }
    }
}
