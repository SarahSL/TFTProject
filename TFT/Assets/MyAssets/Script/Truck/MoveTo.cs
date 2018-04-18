// MoveTo.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform goal;
    void Start()
    {
       // if (Input.GetMouseButton(0)) 
       // {

            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = goal.position;
       // }
    }
    private void Awake()
    {

        goal = GameObject.FindGameObjectWithTag("Goal").transform;
    }
}
