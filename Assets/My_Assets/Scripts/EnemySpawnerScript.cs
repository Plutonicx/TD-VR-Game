using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    public float spawnTime = 1f;
    public GameObject enemy;
    public int maxEnemies = 10;
    int counter;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        counter = 0;
    }

    // Update is called once per frame
    void Spawn()
    {
        if (counter < maxEnemies) {
            Instantiate(enemy, transform.position, transform.rotation);
            counter ++;
        }

    }
}
