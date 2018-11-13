using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseAgent : MonoBehaviour {

    public PrincipalARController principalARController;

    private void Update()
    {
        m_states.m_current.Update();
    }
    #region state management
    private void SM_GoToState(WSC_WarehouseStateController newState)
    {
        m_states.m_current.Exit();
        m_states.m_current = newState;
        m_states.m_current.Enter();
    }

    public void SM_GoToWaiting()
    {
        SM_GoToState(m_states.m_waiting);
    }
    public void SM_GoToSelected()
    {
        SM_GoToState(m_states.m_selected);
    }
    public void SM_GoToInactive()
    {
        SM_GoToState(m_states.m_inactive);
    }

    #endregion

    private void Awake()
    {
        m_states.m_waiting = ScriptableObject.CreateInstance<WSC_Waiting>().Init(this) as WSC_Waiting;
        m_states.m_selected = ScriptableObject.CreateInstance<WSC_Selected>().Init(this) as WSC_Selected;
        m_states.m_inactive = ScriptableObject.CreateInstance<WSC_Inactive>().Init(this) as WSC_Inactive;
        m_states.m_current = m_states.m_waiting;



        SM_GoToWaiting();
    }

    [SerializeField]
    WarehouseStatesController m_states;

    [Serializable]
    public class WarehouseStatesController
    {
        public WSC_WarehouseStateController m_current;

        public WSC_Waiting m_waiting;
        
        public WSC_Selected m_selected;
        
        public WSC_Inactive m_inactive;
    }
}
