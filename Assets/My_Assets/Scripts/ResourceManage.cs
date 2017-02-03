using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManage : MonoBehaviour {

    public int coins;
    public Text uiText;
    public Slider healthSlider;
    int health;

	// Use this for initialization
	void Start () {
        health = 100;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Transaction(int amount)
    {
        coins += amount;
        uiText.text = coins.ToString();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        healthSlider.value = health;
    }
}
