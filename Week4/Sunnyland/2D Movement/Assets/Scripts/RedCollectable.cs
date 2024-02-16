using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCollectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player") 
        {
           Debug.Log("Touched");
            GameManager.instance.UpdateRedScore();
            Destroy(gameObject);
        }
    }
}
