using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] Rigidbody playerlegs;
    
    // Start is called before the first frame update
    private void Awake()
    {
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
        transform.position = spawnPoint.transform.position;
       
    }
   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dead")
        {
            RespawnSpawn();
        }


        if (other.gameObject.tag == "Win")
        {
            winText.enabled = true;
            playerlegs.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
