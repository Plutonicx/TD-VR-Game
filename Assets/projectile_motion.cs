using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_motion : MonoBehaviour {

    GameObject enemyTarget; //make this getable on fixed update.
    Transform enemyTransform; //make this getable on fixed update.

    ParticleSystem hitParticles;
    MeshRenderer dropletMesh;
    bool isActive;

    public float projectileSpeed = 20;
    public float radius = 10;
    int damageCaused = 60;

	// Use this for initialization
	void Awake() {
        hitParticles = GetComponentInChildren<ParticleSystem>();
        dropletMesh = GetComponentInChildren<MeshRenderer>();
        isActive = true;
	}

    void TheStart( GameObject refObject)
    {
        enemyTarget = refObject;
        enemyTransform = enemyTarget.GetComponent<Transform>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        if (enemyTransform != null && isActive){
            //enemyTransform = lockedEnemy.GetComponent<Transform>();

            Vector3 targetVector = (enemyTransform.position - transform.position);

            isTargetHit(targetVector);

            targetVector.Normalize();

            transform.position += targetVector * projectileSpeed * Time.deltaTime;
        }
    }

    private void isTargetHit(Vector3 targetVector)
    {
        if (targetVector.sqrMagnitude <= 0.5)
        {
            if (isActive)
            {
                EnemyHealth enemyHealth = enemyTarget.GetComponent<EnemyHealth>();

                enemyHealth.TakeDamage(damageCaused);

                hitParticles.Play();
                dropletMesh.enabled = false;
                isActive = false;
                Destroy(gameObject, 1f);
            }

        }
    }
}
