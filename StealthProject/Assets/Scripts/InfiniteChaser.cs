using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InfiniteChaser : MonoBehaviour
{
    private NavMeshAgent agent;
    private float distanceFromPoint;
    private float distanceToPlayer;

    private int currentIndex;
    private Vector3 aiPosition, waypointPosition;
    [SerializeField] private Transform destinationPoint;
    [SerializeField] private Transform[] waypoints;

    private AIState currentState;

    private Transform playerFound;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[0].position);
        currentIndex = 0;
        currentState = AIState.Patrol;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentState == AIState.Patrol)
        {


            aiPosition = new Vector3(transform.position.x, waypoints[0].position.y, transform.position.z);
            waypointPosition = waypoints[currentIndex].position;
            distanceFromPoint = Vector3.Distance(aiPosition, waypointPosition);

            if (distanceFromPoint <= 0.1f)
            {
                currentIndex = (currentIndex + 1) % waypoints.Length;



            }
            agent.SetDestination(waypoints[currentIndex].position);
        }
        else if (currentState == AIState.Chase)
        {
            agent.SetDestination(playerFound.position);

            distanceToPlayer = Vector3.Distance(playerFound.position, transform.position);
        }
    }
    public void FoundPlayer(Transform playerToChase)
    {
        playerFound = playerToChase;
        currentState = AIState.Chase;

    }
    
}
