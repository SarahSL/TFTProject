using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class InitSystem : MonoBehaviour
{

    public GameObject principalArCore;
    public GameObject testyController;

    public GameObject gameManagerMain;

    private void Awake()
    {
#if UNITY_ANDROID
        Debug.Log("---- IF UNITY ANDROID -----");
        gameManagerMain.SetActive(true);
        principalArCore.SetActive(true);
        //testyController.SetActive(true);
#elif UNITY_EDITOR
        
        Debug.Log("---- IF UNITY EDITOR ----");
        principalArCore.SetActive(false);
        testyController.SetActive(false);
       gameManagerMain.SetActive(false);
#endif
    }

}
