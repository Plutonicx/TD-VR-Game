using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCreator : MonoBehaviour {

    public float spawnDelay = 3f;

    public EnemySpawnerScript[] waves;
    EnemySpawnerScript currentWave;
    public Text waveText;
    public Color flashColour = new Color(1f, 1f, 1f, 0.5f);
    public float flashSpeed = 0.05f;

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
                ShowWaveNumber();
            }
            catch (Exception e) { }
        }
        else if (timer >= 2 && counter < waves.Length)
        {
            waveText.color = Color.Lerp(waveText.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        else if(counter >= waves.Length)
        {
            waveText.color = flashColour;
            waveText.text = "Game Over. You win!";
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

    private void ShowWaveNumber()
    {
        waveText.color = flashColour;
        waveText.text = "Wave " + (counter + 1).ToString();
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
