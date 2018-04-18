// MoveTo.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform goal;
    void Start()
    {
            Debug.Log(goal.name + "         Nombre del goal     -AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = goal.position;
    }
    private void Awake()
    {
        goal = GameObject.FindGameObjectWithTag("Goal").transform;
    }
}
