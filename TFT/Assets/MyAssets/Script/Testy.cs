using GoogleARCore;
using GoogleARCore.PrincipalAR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Testy : MonoBehaviour
{

    public Camera FirstPersonCamera;
    public GameObject TrackedPlanePrefab;
    public GameObject[] TestyCanvas;
    public GameObject test;
    private List<DetectedPlane> m_NewPlanes = new List<DetectedPlane>();
    //private List<DetectedPlane> m_AllPlanes = new List<DetectedPlane>();
    private bool m_IsQuitting = false;
    private bool placed = false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        _QuitOnConnectionErrors();
        if (!placed)
        {
            if (Session.Status != SessionStatus.Tracking)
            {
                const int lostTrackingSleepTimeout = 15;
                Screen.sleepTimeout = lostTrackingSleepTimeout;
                if (!m_IsQuitting && Session.Status.IsValid())
                {
                    foreach (GameObject TestyCanva in TestyCanvas)
                    {

                        TestyCanva.SetActive(true);
                    }
                }

                return;
            }
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            Session.GetTrackables<DetectedPlane>(m_NewPlanes, TrackableQueryFilter.New);
            for (int i = 0; i < m_NewPlanes.Count; i++)
            {
                GameObject planeObject = Instantiate(TrackedPlanePrefab, Vector3.zero, Quaternion.identity,
                    transform);
                planeObject.GetComponent<TrackedPlaneVisualizer>().Initialize(m_NewPlanes[i]);
            }

            Touch touch;
            if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
            {
                return;
            }

            TrackableHit hit;
            TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
                TrackableHitFlags.FeaturePointWithSurfaceNormal;
            if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
            {
                var anchor = hit.Trackable.CreateAnchor(hit.Pose);
                var testyObject = Instantiate(test, hit.Pose.position, hit.Pose.rotation);
                if ((hit.Flags & TrackableHitFlags.PlaneWithinPolygon) != TrackableHitFlags.None)
                {
                    Vector3 cameraPositionSameY = FirstPersonCamera.transform.position;
                    cameraPositionSameY.y = hit.Pose.position.y;
                    testyObject.transform.LookAt(cameraPositionSameY, testyObject.transform.up);
                }
                placed = true;
                testyObject.transform.parent = anchor.transform;

                PlayableDirector m_director = testyObject.GetComponent<PlayableDirector>();
                m_director.initialTime = 0;
                m_director.Play();
                OnTogglePlanes(false);

            }

        }

    }
    private void _QuitOnConnectionErrors()
    {
        if (m_IsQuitting)
        {
            return;
        }

        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            _ShowAndroidToastMessage("Camera permission is needed to run this application.");
            m_IsQuitting = true;
            Invoke("_DoQuit", 0.5f);
        }
        else if (Session.Status.IsError())
        {
            _ShowAndroidToastMessage("ARCore encountered a problem connecting.  Please start the app again.");
            m_IsQuitting = true;
            Invoke("_DoQuit", 0.5f);
        }
    }

    private void _DoQuit()
    {
        Application.Quit();
    }

    private void _ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity,
                    message, 0);
                toastObject.Call("show");
            }));
        }
    }
    public void OnTogglePlanes(bool flag)
    {
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag("plane"))
        {
            Renderer r = plane.GetComponent<Renderer>();
            TrackedPlaneVisualizer t = plane.GetComponent<TrackedPlaneVisualizer>();
            r.enabled = flag;
            t.enabled = flag;
        }
    }
}
