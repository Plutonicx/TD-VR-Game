using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyShortcuts : MonoBehaviour {

    public GameObject menuPanel;
    public Button[] gameButtons;
    public GameObject settingsPanel;

    bool menuActive = false;
    GameAlive gameAlive;

	// Use this for initialization
	void Start () {
        gameAlive = GetComponent<GameAlive>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && gameAlive.IsGameOver() == false && settingsPanel.active == false)
        {
            toggleMenu();
        }
	}

    public void toggleMenu()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            menuPanel.active = !menuActive;
            toggleButtonsInteractable();
            menuActive = !menuActive;
        }
        else if (Time.timeScale == 0)
        {
            Debug.Log("high");
            Time.timeScale = 1;
            menuPanel.active = !menuActive;
            toggleButtonsInteractable();
            menuActive = !menuActive;
        }
    }

    void toggleButtonsInteractable() {
        foreach(Button button in gameButtons)
        {
            button.interactable = menuActive;
        }
    }
}
