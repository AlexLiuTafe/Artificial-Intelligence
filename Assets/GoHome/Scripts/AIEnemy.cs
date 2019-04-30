using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public Transform target;

    private NavMeshAgent agent; //need to write the "using UnityEngine.AI" if I'm going to use any AI. Reference to the NavMeshAgent component

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update destination of NavMeshAgent
        agent.SetDestination(target.position);
    }
}
