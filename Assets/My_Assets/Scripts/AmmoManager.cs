using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AmmoManager : MonoBehaviour {


    public float spawnTime = 3f;
    public Transform spawnPoint;
    public GameObject enemy;
    public float radius = 10f;
    float timer = 0;
    bool ammoLock = true;

    // Use this for initialization
    void Start () {
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= 3)
        {
            ammoLock = true;
            timer = 0;
        }
            


        if ( ammoLock )
        {
            Spawn();
        }


    }

    void Spawn () {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // find the closest enemy
        //todo - use spherecast to limit search within a small space.
        GameObject enemyReference = null;
        float closestDistance = 999;
        float tempDistance = 0;

        foreach (GameObject enmy in enemies)
        {
            tempDistance = (float) Math.Sqrt((enmy.GetComponent<Transform>().position - transform.position).sqrMagnitude);
            if (tempDistance < radius && tempDistance < closestDistance)
            {
                //Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
                enemyReference = enmy;
                closestDistance = tempDistance;
                ammoLock = false;
            }

        }

        if (enemyReference != null)
        {
            GameObject ammo = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            ammo.SendMessage("TheStart", enemyReference);
        }

    }

}
