// MoveTo.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    private NavMeshAgent agent;
    public Transform goal;
    public void Move()
    {
        agent = FindObjectOfType<NavMeshAgent>();
        agent.destination = goal.position;
    }
}
