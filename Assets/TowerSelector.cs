using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour {

    int towerMask;
    int buttonMask;
    float camRayLength = 100f;
    colorSwitcher towerColor;
    GameObject tower;
    bool keepSelected;

    // Use this for initialization
    void Start () {
        towerMask = LayerMask.GetMask("Tower");
        buttonMask = LayerMask.GetMask("UIButton");
        keepSelected = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit selectHit;

            if (Physics.Raycast(camRay, out selectHit, camRayLength, towerMask))
            {
                towerColor = selectHit.collider.GetComponent<colorSwitcher>();
                towerColor.SelectTower();

                //newPosition.y = 0;
                //ghostTowerTransform.position = new Vector3(newPosition.x, ghostTowerTransform.position.y, newPosition.z);
            }
            else if (!keepSelected)
            {
                try
                {
                    towerColor.DeSelectTower();
                }
                catch (Exception e) { }
            }
        }
    }

    public void KeepSelected()
    {
        keepSelected = true;
        try
        {
            towerColor.SelectTower();
        }
        catch (Exception e) { }
    }

    public void DontKeepSelected()
    {
        keepSelected = false;
    }

    public void UpgradeSelectedTower()
    {
        try
        {
            towerColor.UpgradeTower();
        }
        catch (Exception e) { }
    }
}
