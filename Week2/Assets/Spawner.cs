using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject mushroomPrefab;
    [SerializeField]
    private float spawnTime;

    private float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    if(timer >= spawnTime)
        {
           GameObject g = Instantiate(mushroomPrefab,new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            g.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0,256), Random.Range(0, 256, Random.Range(0, 256));
            timer = 0;
        }

}
}
