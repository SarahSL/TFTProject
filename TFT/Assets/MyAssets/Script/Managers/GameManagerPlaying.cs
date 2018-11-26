using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerPlaying : MonoBehaviour {

    public PrincipalARController principalARController;
    public GameObject truckSelected;
    public PoolTruckController poolTruck;

    public GameObject wareLinkText;

    public int warehousesActualCapacity;
    public int warehousesTotalCapacity;

    public int points;

    private void Update()
    {
        m_states.m_current.Update();
    }
    #region state management
    private void GPS_GoToState(GPS_GamePlayingState newState)
    {
        m_states.m_current.Exit();
        m_states.m_current = newState;
        m_states.m_current.Enter();
    }
    public void GPS_GoToPlaying_Waiting()
    {
        GPS_GoToState(m_states.m_playing_waiting);
    }
    public void GPS_GoToPlaying_TruckSelected()
    {
        GPS_GoToState(m_states.m_playing_truckSelected);
    }
    public void GPS_GoToInactive()
    {
        GPS_GoToState(m_states.m_inactive);
    }
    #endregion
    private void Awake()
    {
        points = 0;

        m_states.m_playing_truckSelected = ScriptableObject.CreateInstance<GPS_Playing_TruckSelected>().Init(this) as GPS_Playing_TruckSelected;
        m_states.m_playing_waiting = ScriptableObject.CreateInstance<GPS_Playing_Waiting>().Init(this) as GPS_Playing_Waiting;
        m_states.m_inactive = ScriptableObject.CreateInstance<GPS_Inactive>().Init(this) as GPS_Inactive;

        m_states.m_current = m_states.m_inactive;
        GPS_GoToInactive();
    }
    [SerializeField]
    GameManagerPlayingStates m_states;

    [System.Serializable]
    public class GameManagerPlayingStates
    {
        public GPS_GamePlayingState m_current;
        
        public GPS_Playing_TruckSelected m_playing_truckSelected;
        public GPS_Playing_Waiting m_playing_waiting;
        public GPS_Inactive m_inactive;


    }


    public void NewTruck(int oldPosition)
    {
        points += 10;
        poolTruck.NewTruck(oldPosition);
    }
}

