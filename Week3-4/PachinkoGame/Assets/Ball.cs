using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        switch(tag)
        {
            case "Zone1":
                GameManager.instance.multiplier = 3;
                break;

            case "Zone2":
                GameManager.instance.multiplier = 2;
                break;

            case "Zone3":
                GameManager.instance.multiplier = 5;
                break;

            case "RedBall":
                GameManager.instance.UpdateScore(10, 1);
                break;

            case "YellowBall":
                GameManager.instance.UpdateScore(20, 1);
                break;

            case "GreenTriangle":
                GameManager.instance.UpdateScore(10, 0);
                break; 
            default:
                break;
        }
    }
}
