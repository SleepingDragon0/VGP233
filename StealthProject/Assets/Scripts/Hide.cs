using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    [SerializeField] float startTime;
    private float realTime;
    [SerializeField] GameObject player;
    private Renderer rend;
    [SerializeField] Material cloak;

    [SerializeField] Material uncloaked;

    // Start is called before the first frame update
    void Start()
    {
        realTime = startTime;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        realTime -= Time.deltaTime;
        if (Input.GetKey(KeyCode.C) && realTime <= 0)
        {
            realTime = startTime;
            player.tag = "Cloaked";
            rend.sharedMaterial = cloak;
        }
        else if (realTime <= 0)
        {
            player.tag = "Player";
            rend.sharedMaterial = uncloaked;

        }
    }
   
}


