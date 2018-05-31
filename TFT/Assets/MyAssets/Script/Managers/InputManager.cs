using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    // Use this for initialization
    public Camera firstPersonCamera;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (TouchAction != null)
            {
                TouchAction(Input.GetTouch(0).position);
            }
        }
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (TouchAction != null)
            {
                TouchAction(new Vector2(0f, 0f));
            }

        }
        */

    }


    public event Action<Vector2> TouchAction;
}
