using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    // Use this for initialization
    public PrincipalARController principalARController;

    void Start()
    {
        Debug.Log("HERE is the Input Manager");
        principalARController = FindObjectOfType<PrincipalARController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit h;
        if (Physics.Raycast(principalARController.m_references.FirstPersonCamera.ScreenPointToRay(Input.GetTouch(0).position), out h))
        {

        }
    }
}
