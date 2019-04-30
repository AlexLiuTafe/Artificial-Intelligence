using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    //all variables needs to be weritten here...
    public enum State
    {
        Patrol,
        Seek
    }
    public State currentState;
    // <Access-Specifier>   <Data-Type>     <Variable-Name> (How to write variables)
         public             Transform        waypointParent; //transform because you want to move or transform the waypoint.
    public float moveSpeed = 2f;
    public float stoppingDistance = 1f;

    public Transform[] waypoints;
    private int currentIndex = 1;
    private NavMeshAgent agent;
    private Transform target;

	// Use this for initialization
	void Start ()
    {
        //Get Children of waypointParent.
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        // Get reference to NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        currentState = State.Patrol;

	}

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Seek:
                Seek();
                break;
            default:
                Patrol();
                break;

        }
        
    }


    void Patrol()
    {
        // 1 - Get the current waypoint
        Transform point = waypoints[currentIndex];
        // 2 - Get distance to waypoint
        float distance = Vector3.Distance(transform.position, point.position);
        // 3 - If close to waypoint
        if(distance < stoppingDistance)
        {
            //  4 - Switch to next waypoint
            currentIndex++; // currentIndex = currentIndex + 1 / Adds 1 to number
            if (currentIndex >= waypoints.Length)
            {
                currentIndex = 1;
            }
        }


        // 5 - Translate enemy to waypoint
        //transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);

        // 5 - Tell NavMeshAgent it's destination
        agent.SetDestination(point.position);
    }
    void Seek()
    {
        //Get enemy to follow target
        agent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            //SET TARGET TO THE THING THAT WE HIT
            target = other.transform;
            //SWITCH STATE OVER TO SEEK
            currentState = State.Seek;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //SWITCH STATE BACK OVER TO PATROL
            currentState = State.Patrol;
        }

    }
}
