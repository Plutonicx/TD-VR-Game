using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_motion : MonoBehaviour {

    Transform dropletTransform;
    public Transform enemyTransform; //make this getable on fixed update.

    public float projectileSpeed = 20;

	// Use this for initialization
	void Awake() {
        dropletTransform = GetComponent<Transform>();
	}

    // Update is called once per frame
    private void Update()
    {
        Vector3 targetVector = (enemyTransform.position- transform.position);
        targetVector.Normalize();

        transform.position += targetVector * projectileSpeed * Time.deltaTime;
    }
}
