using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;
using UnityEngine.Rendering;

#if UNITY_EDITOR
using Input = GoogleARCore.InstantPreviewInput;
#endif
public class GMS_ScanningRoom : GMS_ControllerState
{
    public Camera FirstPersonCamera;
    public GameObject TrackedPlanePrefab;
    public GameObject SearchingForPlaneUI;
    private List<TrackedPlane> m_NewPlanes = new List<TrackedPlane>();
    private List<TrackedPlane> m_AllPlanes = new List<TrackedPlane>();
    private bool m_IsQuitting = false;

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Update()
    {

    }
}
