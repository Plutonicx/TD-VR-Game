using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildToggle : MonoBehaviour {

    public GameObject buildPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleBuildPanel()
    {
        try
        {
            if (buildPanel.active)
                buildPanel.SetActive(false);
            else
                buildPanel.SetActive(true);

        }
        catch(Exception e)
        {

        }
    } 
}
