using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    float timer = 0f;
    float nextSpawnTime = 2f;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void GenerateEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-6,6),9,-2), new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>= nextSpawnTime)
        {
            GenerateEnemy();
            nextSpawnTime = Random.Range(1, 4);
            timer = 0f;
        }        
    }
}
