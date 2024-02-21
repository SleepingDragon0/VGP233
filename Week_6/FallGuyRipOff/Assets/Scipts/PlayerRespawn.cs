using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] Vector3 checkPoint;
    [SerializeField] Vector3 spawnPoint;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] Timer timer;
    [SerializeField] Rigidbody playerlegs;
    
    // Start is called before the first frame update
    bool firstCheckpointAchieved;

    private void Awake()
    {
        firstCheckpointAchieved = false;
        winText.enabled = false;

    }
    private void Start()
    {
        

    }
    private void Update()
    {
   
    }
    public void RespawnSpawn()
    {
        transform.position = spawnPoint;
       
    }
    public void RespawnCheck1()
    {
        transform.position = checkPoint;
    }
   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Death")
        {
            if (firstCheckpointAchieved == true)
            {
                RespawnCheck1();
            }
           
            else
            {
                RespawnSpawn();
            }



        }

        if (other.gameObject.tag == "Checkpoint")
        {
            firstCheckpointAchieved = true;
        }

        if (other.gameObject.tag == "Win")
        {
            winText.enabled = true;
            playerlegs.constraints = RigidbodyConstraints.FreezeAll;
            timer.win = true;
        }
    }
}
