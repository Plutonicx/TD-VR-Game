using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelect : MonoBehaviour {

    Renderer myRender;
    public Color newColor;
    Color oldColor;
    bool selected;

    public GameObject towerUpgrade;

    int towerMask;
    float camRayLength = 100f;

    // Use this for initialization
    void Start () {
        myRender = GetComponent<Renderer>();
        oldColor = myRender.material.color;
        selected = false;
        towerMask = LayerMask.GetMask("Tower");
    }
	
	// Update is called once per frame
	void Update () {
        SetColor();
    }

    public void SelectTower()
    {
        selected = true;
    }

    public void DeSelectTower()
    {
        selected = false;
    }

    void SetColor()
    {
        if (selected)
        {
            myRender.material.color = newColor;
        }
        else
        {
            myRender.material.color = oldColor;
        }
    }

    public void UpgradeTower()
    {
        if ( towerUpgrade != null)
        {
            
            Instantiate(towerUpgrade, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject, 0f);
        }
    }
}
