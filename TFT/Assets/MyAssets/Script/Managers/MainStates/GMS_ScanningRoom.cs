using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;
using UnityEngine.AI;
using GoogleARCore.PrincipalAR;
public class GMS_ScanningRoom : GMS_ControllerState
{
    public GameObject principalARControllerObject;
    public PrincipalARController principalARController;
    private List<TrackedPlane> m_NewPlanes = new List<TrackedPlane>();
    private List<TrackedPlane> m_AllPlanes = new List<TrackedPlane>();
    private bool m_IsQuitting = false;
    private bool placed = false;
    
    public override void Enter()
    {
        Debug.Log("HERE WE ARE__ : ScanningRomm.Enter-------");
        principalARController = FindObjectOfType<PrincipalARController>();
    }

    public override void Exit()
    {

        Debug.Log("HERE WE ARE__ : ScanningRomm.Exit-------");
    }

    public override void Update()
    {
        Debug.Log("HERE WE ARE__ : ScanningRomm.Update-------");
        placed = principalARController.placed;
        if (!placed)
        {
            principalARController.Scan();
        }
        else
        {
            m_target.SM_GoToWaitingBox();
        }
    }
}
