using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerGameplay : MonoBehaviour
{
    public PrincipalARController principalARController;

    public GameObject CountDownUI;

    private void Update()
    {
        m_states.m_current.Update();
    }
    #region state management
    private void SM_GoToState(GMGS_GameplayControllerStates newState)
    {
        m_states.m_current.Exit();
        m_states.m_current = newState;
        m_states.m_current.Enter();
    }

    public void SMG_GoToInactive()
    {
        SM_GoToState(m_states.m_inactive);
    }
    public void SMG_GoToInitGame()
    {
        SM_GoToState(m_states.m_initGame);
    }
    public void SMG_GoToCountDown()
    {
        SM_GoToState(m_states.m_countDown);
    }
    public void SMG_GoToPlaying()
    {
        SM_GoToState(m_states.m_playing);
    }
    public void SMG_GoToPause()
    {
        SM_GoToState(m_states.m_pause);
    }
    public void SMG_GoToPoints()
    {
        SM_GoToState(m_states.m_points);
    }
    #endregion
    private void Awake()
    {

       
        m_states.m_inactive = ScriptableObject.CreateInstance<GMGS_Inactive>().Init(this) as GMGS_Inactive;
        m_states.m_initGame = ScriptableObject.CreateInstance<GMGS_InitGame>().Init(this) as GMGS_InitGame;
        m_states.m_countDown = ScriptableObject.CreateInstance<GMGS_CountDown>().Init(this) as GMGS_CountDown;
        
        m_states.m_playing = ScriptableObject.CreateInstance<GMGS_Playing>().Init(this) as GMGS_Playing;
       
        m_states.m_pause = ScriptableObject.CreateInstance<GMGS_Pause>().Init(this) as GMGS_Pause;
        m_states.m_points = ScriptableObject.CreateInstance<GMGS_Points>().Init(this) as GMGS_Points;


        m_states.m_current = m_states.m_inactive;
        SMG_GoToInactive();
    }



    [SerializeField]
    public GameManagerGameplayStates m_states;

    [System.Serializable]
    public class GameManagerGameplayStates
    {
        public GMGS_GameplayControllerStates m_current;

        public GMGS_CountDown m_countDown;
        public GMGS_Inactive m_inactive;
        public GMGS_InitGame m_initGame;
        public GMGS_Pause m_pause;
        public GMGS_Playing m_playing;
        public GMGS_Points m_points;


    }
}
