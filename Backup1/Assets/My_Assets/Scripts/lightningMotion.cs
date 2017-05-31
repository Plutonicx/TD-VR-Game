using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningMotion : MonoBehaviour {

    LineRenderer lightningLine;
    GameObject enemyTarget;

    public float timeEffect = 0.15f;
    public int damageCaused = 60;

    float timer = 0;
    bool isActive;

    // Use this for initialization
    void Start () {
        lightningLine = GetComponent<LineRenderer>();
        isActive = true;
    }

    void TheStart(GameObject refObject)
    {
        enemyTarget = refObject;
        timer = 0;
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;

        if (enemyTarget != null && timer <= timeEffect && Time.timeScale != 0)
        {
            Spawn();
        }

        if ( timer >= timeEffect && enemyTarget != null && isActive)
        {
            DisableEffects();
        }
	}

    void Spawn()
    {
        lightningLine.SetPosition(0, transform.position);
        lightningLine.SetPosition(1, enemyTarget.transform.position);
    }

    public void DisableEffects()
    {
        isActive = false;

        EnemyHealth enemyHealth = enemyTarget.GetComponent<EnemyHealth>();

        enemyHealth.TakeDamage(damageCaused);

        //hitParticles.Play();

        lightningLine.enabled = false;
        //lightningLight.enabled = false;
        Destroy(gameObject, 1f);
    }
}
