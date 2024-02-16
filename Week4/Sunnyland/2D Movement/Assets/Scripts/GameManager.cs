using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject ToExplode;


    [SerializeField]
    TextMeshProUGUI header;

    [SerializeField]
    TextMeshProUGUI redScore;

    [SerializeField]
    TextMeshProUGUI blueScore;

    [SerializeField]
    TextMeshProUGUI gameOverText;

    int blueCollected;
    int redCollected;

    [SerializeField]
    float timer;

    public static GameManager instance;

    public bool deadRun;




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


        blueCollected = 0;
        redCollected = 0;

        deadRun = false;
    }
    void Update()
    {
        if(blueCollected >= 10 && redCollected >= 10)
        {
            header.text = "You Win";
        }
        if(deadRun == true)
        {
            gameOverText.gameObject.SetActive(true);
            timer = timer - 1 * Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }

        }

    }


    public void UpdateRedScore()
    {
        redCollected += 1;
        redScore.text =  redCollected + " Red Shrooms collected";
    }
    public void UpdateBlueScore()
    {
        blueCollected += 1;
        //blueScore.text = blueCollected + " Blue Shrooms collected";
    }
    public void Explode()
    {
        Destroy(ToExplode);
    }




}
