using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerGhosting : MonoBehaviour {

    Vector3 targetCamPos;
    Transform ghostTowerTransform;

    public GameObject resourceManager;
    public GameObject tower;
    public GameObject towerHolder;
    public Terrain terrain;
    GameObject ghostTower;

    
    ResourceManage myCoins;
    TowerHolder holder;
    TowerSelector towerSelect;

    int floorMask;
    float camRayLength = 100f;

    // Use this for initialization
    void Awake () {
        floorMask = LayerMask.GetMask("Floor");
        //GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost"); //TODO: On fixed update search for ghost towers.
        ghostTowerTransform = null;
        myCoins = resourceManager.GetComponent<ResourceManage>();
        towerSelect = GetComponent<TowerSelector>();
        holder = GetComponent<TowerHolder>();

        try
        {
          //  ghostTowerTransform = ghosts[0].GetComponent<Transform>();
        }
        catch(Exception e)
        {

        }
        
    }

    public void CreateTowerGhost()
    {
        ghostTower = Instantiate(towerHolder, new Vector3(0,0.9f,0), Quaternion.Euler(-90,0,0));
        ghostTowerTransform = ghostTower.transform;
    }

    public void CreateTowerGhost(string towerType)
    {
        tower = holder.getTowerFromName(towerType);
        towerHolder = holder.getGhostTowerFromName(towerType);

        // bugs are temporarily fixed here. Need to change this in the future.
        ghostTower = Instantiate(towerHolder, new Vector3(0, 0.9f, 0), Quaternion.Euler(-90, 0, 0));


        ghostTowerTransform = ghostTower.transform;
    }

    // Update is called once per frame
    void Update () {

        if (ghostTowerTransform != null)
        {

            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit floorHit;

            if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
            {
                Vector3 newPosition = floorHit.point;

                newPosition.x = Mathf.Floor(newPosition.x) + 0.5f;
                newPosition.z = Mathf.Floor(newPosition.z) + 0.5f;

                //newPosition.y = 0;
                ghostTowerTransform.position = new Vector3(newPosition.x, ghostTowerTransform.position.y, newPosition.z);
            }


            if (Input.GetMouseButtonDown(0) && (int) myCoins.coins >= 20)
            {
                if (IsNotOverlappingOtherTowers(ghostTowerTransform.position) && IsNotOnWalkWay(ghostTowerTransform.position))
                {
                    Instantiate(tower, ghostTowerTransform.position, ghostTowerTransform.rotation);
                    myCoins.Transaction(-20);
                }
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            Destroy(ghostTower, 0f);
            //ghostTower = null;
            ghostTowerTransform = null;
        }

        if (ghostTowerTransform != null && (int) myCoins.coins < 20)
        {
            try
            {
               // ghostTower.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0.8f);
            }
            catch(Exception e)
            {

            }
        }

    }

    bool IsNotOverlappingOtherTowers(Vector3 position)
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

        foreach(GameObject tower in towers)
        {
            if (Math.Abs(tower.transform.position.x - position.x) < 1 && Math.Abs(tower.transform.position.z - position.z) < 1)
            {
                towerSelect.DeSelect();
                return false;
            }
        }

        return true;
    }

    bool IsNotOnWalkWay(Vector3 posiition)
    {
        float x = posiition.x;
        float z = posiition.z;
        float y = posiition.y;

        float h1 = terrain.SampleHeight(new Vector3(x + 0.5f, y, z + 0.5f));
        float h2 = terrain.SampleHeight(new Vector3(x + 0.5f, y, z - 0.5f));
        float h3 = terrain.SampleHeight(new Vector3(x - 0.5f, y, z + 0.5f));
        float h4 = terrain.SampleHeight(new Vector3(x - 0.5f, y, z - 0.5f));

        if (h1 < 0.25 ||
            h2 < 0.25 ||
            h3 < 0.25 ||
            h4 < 0.25)
            return false;

        return true;
    }

}
