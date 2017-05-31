using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAlive : MonoBehaviour {

    public ResourceManage resources;
    public GameObject[] gamePanels;
    public GameObject gameOverPanel;

    bool isGameOver;

	// Use this for initialization
	void Start () {
        isGameOver = false;

    }
	
	// Update is called once per frame
	void Update () {
		if (IsGameOver() && !isGameOver) // dont keep running this if game is over.
        {
            GameOver();
        }
	}

    public void GameOver()
    {
            Time.timeScale = 0;
            isGameOver = true;
            togglePanelsInteractable();
            gameOverPanel.SetActive(true);
    }

    public void ReturnTimeToNormal()
    {
        Time.timeScale = 1;
    }

    private void togglePanelsInteractable()
    {
        foreach(GameObject panel in gamePanels)
        {
            panel.SetActive(false);
        }
    }

    public bool IsGameOver()
    {
        if (resources.GetHealth() <= 0)
            return true;

        return false;
    }
}
