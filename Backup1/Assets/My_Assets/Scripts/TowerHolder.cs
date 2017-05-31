using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHolder : MonoBehaviour {

    public GameObject waterTower;
    public GameObject waterTowerGhost;

    public GameObject lightningTower;
    public GameObject lightningTowerGhost;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject getTowerFromName(string towerName)
    {
        if (towerName == "water")
            return waterTower;

        if (towerName == "lightning")
            return lightningTower;

        return null;
    }

    public GameObject getGhostTowerFromName(string towerName)
    {
        if (towerName == "water")
            return waterTowerGhost;

        if (towerName == "lightning")
            return lightningTowerGhost;

        return null;
    }
}
