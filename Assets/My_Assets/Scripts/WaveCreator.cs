using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCreator : MonoBehaviour {

    public float spawnDelay = 3f;

    public EnemySpawnerScript[] waves;
    EnemySpawnerScript currentWave;

    int counter;
    float timer;
    bool spawnTrigger;

    // Use this for initialization
    void Start () {
        counter = 0;
        timer = 0;
        spawnTrigger = false;
        try
        {
            currentWave = waves[counter];
            currentWave.BeginSpawning();
        }
        catch (Exception e) { }
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

		if (CheckIfWaveOver() && counter < waves.Length)
        {
            counter++;
            try
            {
                currentWave = waves[counter];
                ResetTimer();
            }
            catch (Exception e) { }
        }

        if (spawnTrigger && timer >= spawnDelay)
        {
            try
            {
                currentWave.BeginSpawning();
                spawnTrigger = false;
            }
            catch (Exception e) { }
        }
	}

    private void ResetTimer()
    {
        timer = 0;
        spawnTrigger = true;
    }

    private bool CheckIfWaveOver()
    {
        if (currentWave.HasEnemies() == false)
            return true;

        return false;
    }
}
