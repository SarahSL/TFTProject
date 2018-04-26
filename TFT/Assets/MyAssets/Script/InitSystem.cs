using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSystem : MonoBehaviour
{

    public GameObject principalArCore;
    public GameObject testyController;

    private void Awake()
    {
#if UNITY_EDITOR
        Debug.Log("---- IF UNITY EDITOR ----");
        principalArCore.SetActive(false);
        testyController.SetActive(false);

#elif UNITY_ANDROID
        Debug.Log("---- IF UNITY ANDROID -----");
        principalArCore.SetActive(true);
        //testyController.SetActive(true);
#endif

    }

}
