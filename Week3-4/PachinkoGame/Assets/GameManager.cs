using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour   
{
    [SerializeField]
    GameObject ball, scoreText;

    int score;


    [SerializeField]
    Vector3 startPos;

    public int multiplier;

    public static GameManager instance;

    [SerializeField]
    private float spawnTime;

    private float timer;

    private void Awake()
    {
        startPos = new Vector3(Random.Range(-2, 2), 4.42f, 0);
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
        if(Input.GetKey(KeyCode.Space))
        {
            Instantiate(ball, startPos, Quaternion.identity);
        }
        }
    }

    public void UpdateScore(int ball, int mulIncrease)
    {
        multiplier += mulIncrease;
        score += ball * multiplier;
        scoreText.GetComponent<Text>().text = "Score: " + score;
    }




}
