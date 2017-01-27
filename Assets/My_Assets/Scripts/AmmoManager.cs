using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AmmoManager : MonoBehaviour {


    public float spawnTime = 3f;
    public Transform spawnPoint;
    public GameObject enemy;
    public float radius = 10.5f;


    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
	
	
	void Spawn () {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // find the closest enemy

        foreach (GameObject enmy in enemies)
        {
            float tempDistance = (enmy.GetComponent<Transform>().position - transform.position).sqrMagnitude;
            if (Math.Sqrt(tempDistance) < radius)
            {
                Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            }

        }



    }
}
