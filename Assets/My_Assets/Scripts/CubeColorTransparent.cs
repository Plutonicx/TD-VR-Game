using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorTransparent : MonoBehaviour {

    public Color ObjectColor;

    // Use this for initialization
    void Awake () {
        GetComponent<Renderer>().material.color = ObjectColor;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
