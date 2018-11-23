using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TruckAgent : MonoBehaviour
{
    public PrincipalARController principalARController;
    public NavMeshAgent agent;
    public WarehouseAgent warehouseSelected;
    public GameManagerPlaying gameManagerPlaying;

    public int load;
    public int typeLoad;
    public int idTruck;

    private void Update()
    {
        m_states.m_current.Update();
    }
    #region state management
    private void SM_GoToState(TSC_TruckControllerState newState)
    {
        m_states.m_current.Exit();
        m_states.m_current = newState;
        m_states.m_current.Enter();
    }

    public void SM_GoToWaiting()
    {
        SM_GoToState(m_states.m_waiting);
    }

    public void SM_GoToAngry()
    {
        SM_GoToState(m_states.m_angry);
    }
    public void SM_GoToSelected()
    {
        SM_GoToState(m_states.m_selected);
    }
    public void SM_GoToOnWay()
    {
        SM_GoToState(m_states.m_onway);
    }
    public void SM_GoToInactive()
    {
        SM_GoToState(m_states.m_inactive);
    }

    #endregion

    private void Awake()
    {
        
        SetTruck();

        m_states.m_waiting = ScriptableObject.CreateInstance<TSC_Waiting>().Init(this) as TSC_Waiting;
        m_states.m_angry = ScriptableObject.CreateInstance<TSC_Angry>().Init(this) as TSC_Angry;
        m_states.m_selected = ScriptableObject.CreateInstance<TSC_Selected>().Init(this) as TSC_Selected;
        m_states.m_onway = ScriptableObject.CreateInstance<TSC_OnWay>().Init(this) as TSC_OnWay;
        m_states.m_inactive = ScriptableObject.CreateInstance<TSC_Inactive>().Init(this) as TSC_Inactive;
        m_states.m_current = m_states.m_waiting;
        
        SM_GoToWaiting();
    }

    [SerializeField]
    TruckControllerStates m_states;

    [Serializable]
    public class TruckControllerStates
    {
        public TSC_TruckControllerState m_current;

        public TSC_Waiting m_waiting;
        public TSC_Angry m_angry;
        public TSC_Selected m_selected;
        public TSC_OnWay m_onway;
        public TSC_Inactive m_inactive;
    }



    public TextMesh typeLoadText;
    public TextMesh loadText;

    private void SetTruck()
    {
        gameManagerPlaying = FindObjectOfType<GameManagerPlaying>();
        int aux = gameManagerPlaying.warehousesActualCapacity / 2;
        if (aux == 0)
        {
            load = UnityEngine.Random.Range(30, 60);
        }
        else
        {
            load = UnityEngine.Random.Range(1, aux);
        }

        //MEJORAR
        loadText.text = "" + load;
        typeLoad = UnityEngine.Random.Range(1,3);
        switch (typeLoad)
        {
            case 1:
                typeLoadText.text = "Grande";
                break;
            case 2:

                typeLoadText.text = "Pequeño";
                break;
            case 3:

                typeLoadText.text = "Fragil";
                break;
        } 

    }

   
}
