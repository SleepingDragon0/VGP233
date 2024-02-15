using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCollectable : MonoBehaviour
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
        if (other.tag == "player2") 
        {
            Debug.Log("Touched");
            GameManager.instance.UpdateBlueScore();
            Destroy(gameObject);
        }
    }
}
