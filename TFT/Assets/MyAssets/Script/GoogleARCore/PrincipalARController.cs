using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;
using UnityEngine.AI;
using GoogleARCore.PrincipalAR;
#if UNITY_EDITOR
    using Input = GoogleARCore.InstantPreviewInput;
#endif
public class PrincipalARController : MonoBehaviour
{
    
    private List<TrackedPlane> m_NewPlanes = new List<TrackedPlane>();
    private List<TrackedPlane> m_AllPlanes = new List<TrackedPlane>();
    private bool m_IsQuitting = false;
    [HideInInspector]
    public bool placed = false;

    public GameObject boxObject;
    public GameObject videoObject;

    public PrincipalARControllerReferences m_references;
    public PrincipalARControllerInstanciables m_instanciables;

    public void Scan()
    {

        if (!placed)
        {
            if (Session.Status != SessionStatus.Tracking)
            {
                const int lostTrackingSleepTimeout = 15;
                Screen.sleepTimeout = lostTrackingSleepTimeout;
                if (!m_IsQuitting && Session.Status.IsValid())
                {
                    m_references.SearchingForPlaneUI.SetActive(true);
                }

                return;
            }

            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            Session.GetTrackables<TrackedPlane>(m_NewPlanes, TrackableQueryFilter.New);
            for (int i = 0; i < m_NewPlanes.Count; i++)
            {
                GameObject planeObject = Instantiate(m_references.TrackedPlanePrefab, Vector3.zero, Quaternion.identity,
                    transform);
                planeObject.GetComponent<TrackedPlaneVisualizer>().Initialize(m_NewPlanes[i]);
            }
            bool showSearchingUI = true;
            Session.GetTrackables<TrackedPlane>(m_AllPlanes);
            for (int i = 0; i < m_AllPlanes.Count; i++)
            {
                if (m_AllPlanes[i].TrackingState == TrackingState.Tracking)
                {
                    showSearchingUI = false;
                    break;
                }
            }

            m_references.SearchingForPlaneUI.SetActive(showSearchingUI);

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
                boxObject = Instantiate(m_instanciables.BoxPrefab, hit.Pose.position,Quaternion.identity);
                videoObject = Instantiate(m_instanciables.VideoPrefab, hit.Pose.position, Quaternion.identity);
                videoObject.SetActive(false);
                boxObject.transform.LookAt(m_references.FirstPersonCamera.transform.position);
                boxObject.transform.eulerAngles = new Vector3(0, boxObject.transform.eulerAngles.y, 0);

                videoObject.transform.LookAt(m_references.FirstPersonCamera.transform.position);
                videoObject.transform.eulerAngles = new Vector3(0, boxObject.transform.eulerAngles.y, 0);
                

                if ((hit.Flags & TrackableHitFlags.PlaneWithinPolygon) != TrackableHitFlags.None)
                {
                    Vector3 cameraPositionSameY = m_references.FirstPersonCamera.transform.position;
                    cameraPositionSameY.y = hit.Pose.position.y;
                    boxObject.transform.LookAt(cameraPositionSameY, boxObject.transform.up);
                    videoObject.transform.LookAt(cameraPositionSameY, boxObject.transform.up);
                }
                boxObject.transform.parent = anchor.transform;
                videoObject.transform.parent = anchor.transform;
                
                placed = true;
                foreach (GameObject plane in GameObject.FindGameObjectsWithTag("Plane"))
                {
                    Renderer r = plane.GetComponent<Renderer>();
                    TrackedPlaneVisualizer t = plane.GetComponent<TrackedPlaneVisualizer>();
                    r.enabled = false;
                    t.enabled = false;
                }
            }

        }
    }


    [System.Serializable]
    public class PrincipalARControllerInstanciables
    {
        public GameObject BoxPrefab;
        public GameObject VideoPrefab;


    }
    [System.Serializable]
    public class PrincipalARControllerReferences
    {
        public Camera FirstPersonCamera;
        public GameObject TrackedPlanePrefab;

        public GameObject SearchingForPlaneUI;
    }





    // EXIT FOR ANDROID ARCORE && ERRORS

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
    
    private void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        _QuitOnConnectionErrors();
    }

}

