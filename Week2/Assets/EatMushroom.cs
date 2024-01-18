using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatMushroom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "Consumable")
        {
            Debug.Log("Devour Mushroom");
            Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
