using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManage : MonoBehaviour {

    public int coins;
    public Text uiText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Transaction(int amount)
    {
        coins += amount;
        uiText.text = coins.ToString();
    }
}
