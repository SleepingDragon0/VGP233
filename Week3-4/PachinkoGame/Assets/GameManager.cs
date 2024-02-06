using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour   
{
    [SerializeField]
    GameObject ball;

    [SerializeField]
    GameObject tracer;

    [SerializeField]
    TextMeshProUGUI scoreText;

    int score;

    public int multiplier;

    public static GameManager instance;

    [SerializeField]
    private float spawnTime;

    [SerializeField]
    private float speed;

    private float timer;

    private Vector3 spawnerpos;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        score = 0;
        multiplier = 1;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime) { 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(ball, tracer.transform.position, Quaternion.identity);

        }
        }
        
    }

    public void UpdateScore(int ball, int mulIncrease)
    {
        multiplier += mulIncrease;
        score += ball * multiplier;
        scoreText.text = "Score: " + score;
    }




}
