using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSystem : MonoBehaviour {

    public GameObject principalArCore; 

    private void Awake()
    {
    #if UNITY_EDITOR
            Debug.Log("---- IF UNITY EDITOR ----");
            principalArCore.SetActive(false);

    #elif UNITY_ANDROID
        Debug.Log("---- IF UNITY ANDROID -----");
        principalArCore.SetActive(true);
    #endif

    }

}
