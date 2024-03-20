using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class RunAway : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private GameObject player;
    [SerializeField] private float EnemyDistanceRun;

    private float distancefromplayer;

  

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
         distancefromplayer = Vector3.Distance(transform.position, player.transform.position);

       if (distancefromplayer < EnemyDistanceRun)
        {
            //vector of player to enemy
            Vector3 directionToPlayer = transform.position - player.transform.position;
            Vector3 newPos = transform.position + directionToPlayer;
            agent.SetDestination(newPos);
        }
      

    }
}

          
            
  