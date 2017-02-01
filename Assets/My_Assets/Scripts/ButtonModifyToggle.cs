using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonModifyToggle : MonoBehaviour {

    public GameObject additionalOptionsPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleAdditionalOptions()
    {
        try
        {
            if (additionalOptionsPanel.active)
            {
                additionalOptionsPanel.active = false;
            }
            else
            {
                additionalOptionsPanel.active = true;
            }
        }
        catch(Exception e)
        {

        }
    }
}
