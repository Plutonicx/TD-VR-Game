using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostColourSwitcher : MonoBehaviour {

    Renderer ghostRender;

    ResourceManage resources;
    public Color newColor;
    Color oldColor;

	// Use this for initialization
	void Start () {
        ghostRender = GetComponent<Renderer>();
        oldColor = ghostRender.material.color;
        try
        {
            GameObject resourceManager = GameObject.FindGameObjectsWithTag("ResourceManager")[0];
            resources = resourceManager.GetComponent<ResourceManage>();
        }
        catch(Exception e)
        {

        }


    }
	
	// Update is called once per frame
	void Update () {
        SetColor();
	}

    void SetColor()
    {
        if (resources.coins < 20)
        {
            ghostRender.material.color = newColor;
        }
        else
        {
            ghostRender.material.color = oldColor;
        }
    }
}
