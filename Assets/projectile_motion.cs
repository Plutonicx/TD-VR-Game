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

    void TheStart( GameObject refObject)
    {
        enemyTransform = refObject.GetComponent<Transform>();
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
                hitParticles.Play();
                dropletMesh.enabled = false;
                isActive = false;
                Destroy(gameObject, 1f);
            }

        }
    }
}
