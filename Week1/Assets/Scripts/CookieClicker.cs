using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieClicker : MonoBehaviour
{
    
     int score;
    [SerializeField] int clickBonus = 3;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Update!");

    }
    public void addScore()
    {
        score+=clickBonus;
        Debug.Log("Score: "+ score);

    }

}
