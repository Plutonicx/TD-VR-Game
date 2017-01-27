using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_motion : MonoBehaviour {

    Transform enemyTransform; //make this getable on fixed update.

    ParticleSystem hitParticles;
    MeshRenderer dropletMesh;
    bool isActive;

    public float projectileSpeed = 20;
    public float radius = 10;

	// Use this for initialization
	void Awake() {
        hitParticles = GetComponentInChildren<ParticleSystem>();
        dropletMesh = GetComponentInChildren<MeshRenderer>();
        isActive = true;
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (enemyTransform == null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            // find the closest enemy
            float closestDistance = 999;
            float tempDistance;

            foreach (GameObject enemy in enemies)
            {
                tempDistance = (enemy.GetComponent<Transform>().position - transform.position).sqrMagnitude;
                if (Math.Sqrt(tempDistance) < closestDistance && Math.Sqrt(tempDistance) < radius)
                {
                    closestDistance = (float) Math.Sqrt(tempDistance);
                    enemyTransform = enemy.GetComponent<Transform>();
                }

            }
        }

        if (enemyTransform != null){
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
                hitParticles.Play();
                dropletMesh.enabled = false;
                isActive = false;
                Destroy(gameObject, 2f);
            }

        }
    }
}
