using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class InitSystem : MonoBehaviour
{
    public GameObject principalArCore;
    public GameObject gameManagerMain;
    public GameObject gameManagerGameplay;
    private void Awake()
    {
#if UNITY_ANDROID
        Debug.Log("---- IF UNITY ANDROID -----");
        gameManagerMain.SetActive(true);
        principalArCore.SetActive(true);
        gameManagerGameplay.SetActive(true);
#elif UNITY_EDITOR

        Debug.Log("---- IF UNITY EDITOR ----");
        principalArCore.SetActive(false);
        gameManagerMain.SetActive(false);
        gameManagerGameplay.SetActive(false);
#endif
    }

}
