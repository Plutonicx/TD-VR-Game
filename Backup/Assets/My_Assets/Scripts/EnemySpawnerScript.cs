using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    public float spawnTime = 1f;
    public GameObject enemy;
    public int maxEnemies = 10;
    int counter;

    bool hasEnemies;

    List<GameObject> enemies;

    // Use this for initialization
    void Start()
    {
        counter = 0;
        enemies = new List<GameObject>();
        hasEnemies = true;
        //Begin();
    }

    public void BeginSpawning()
    {
        Debug.Log("Wave Spawning with timer " + spawnTime.ToString());
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (counter < maxEnemies) {
            GameObject newEnemy = Instantiate(enemy, transform.position, transform.rotation);
            enemies.Add(newEnemy);
            counter ++;
        }
        else
        {
            try
            {
                foreach (GameObject enmy in enemies)
                {
                    if (enmy == null)
                        enemies.Remove(enmy);
                }
            }
            catch (Exception e) { }
        }

    }

    void Update()
    {
        

        if (enemies.Count <= 0 && counter >= maxEnemies)
            hasEnemies = false;
    }

    public bool HasEnemies()
    {
        return hasEnemies;
    }
}
