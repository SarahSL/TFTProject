
using UnityEngine;
using UnityEngine.Playables;

public class GMS_WaitingBox : GMS_ControllerState
{
    public PrincipalARController principalARController;
    public PlayableDirector m_director;
    public override void Enter()
    {
        principalARController = FindObjectOfType<PrincipalARController>();
        principalARController.boxObject.SetActive(true);

        m_director = principalARController.boxObject.GetComponent<PlayableDirector>();
        
        m_director.initialTime = 0;
        m_director.Play();
    }

    public override void Exit()
    {
       
    }

    public override void Update()
    {

        if (m_director.state != PlayState.Playing)
        {
            m_target.SM_GoToMenu();
        }

    }
}
