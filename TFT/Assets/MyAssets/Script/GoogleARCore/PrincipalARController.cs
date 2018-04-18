//-----------------------------------------------------------------------
// <copyright file="HelloARController.cs" company="Google">
//
// Copyright 2017 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

// TO DO: REFACTOR

namespace GoogleARCore.PrincipalAR
{
    using System.Collections.Generic;
    using GoogleARCore;
    using UnityEngine;
    using UnityEngine.Rendering;

#if UNITY_EDITOR
    using Input = InstantPreviewInput;
    using UnityEngine.AI;
#endif

    public class PrincipalARController : MonoBehaviour
    {
        public Camera FirstPersonCamera;
        public GameObject TrackedPlanePrefab;
        public GameObject BoxPrefab;
        public GameObject StreetPrefab;
        public GameObject SearchingForPlaneUI;
        private List<TrackedPlane> m_NewPlanes = new List<TrackedPlane>();
        private List<TrackedPlane> m_AllPlanes = new List<TrackedPlane>();
        private bool m_IsQuitting = false;
        private bool placed = false;
        public void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            _QuitOnConnectionErrors();


                if (Session.Status != SessionStatus.Tracking && !placed)
                {
                    const int lostTrackingSleepTimeout = 15;
                    Screen.sleepTimeout = lostTrackingSleepTimeout;
                    if (!m_IsQuitting && Session.Status.IsValid())
                    {
                        SearchingForPlaneUI.SetActive(true);
                    }

                    return;
                }

                Screen.sleepTimeout = SleepTimeout.NeverSleep;

                Session.GetTrackables<TrackedPlane>(m_NewPlanes, TrackableQueryFilter.New);
                for (int i = 0; i < m_NewPlanes.Count; i++)
                {
                    GameObject planeObject = Instantiate(TrackedPlanePrefab, Vector3.zero, Quaternion.identity,
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

                SearchingForPlaneUI.SetActive(showSearchingUI);

                Touch touch;
                if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
                {
                    return;
                }

                TrackableHit hit;
                TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
                    TrackableHitFlags.FeaturePointWithSurfaceNormal;
            if (!placed)
            {
                if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit) )
                {
                    var streetObject = Instantiate(StreetPrefab, hit.Pose.position, hit.Pose.rotation);
                    var anchor = hit.Trackable.CreateAnchor(hit.Pose);
                    streetObject.transform.parent = anchor.transform;
                    surface.position = streetObject.transform.position;
                    GameObject start = GameObject.FindGameObjectWithTag("Goal");
                    var boxObject = Instantiate(BoxPrefab, start.transform.position, hit.Pose.rotation);
                    if ((hit.Flags & TrackableHitFlags.PlaneWithinPolygon) != TrackableHitFlags.None)
                    {
                        Vector3 cameraPositionSameY = FirstPersonCamera.transform.position;
                        cameraPositionSameY.y = hit.Pose.position.y;
                        boxObject.transform.LookAt(cameraPositionSameY, boxObject.transform.up);
                    }
                    boxObject.transform.parent = anchor.transform;
                    placed = true;
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
    }
}
