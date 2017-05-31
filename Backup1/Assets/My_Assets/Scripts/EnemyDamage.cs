using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    Collider destination;
    ResourceManage resources;

    CapsuleCollider myCollider;

	// Use this for initialization
	void Start () {
        myCollider = GetComponent<CapsuleCollider>();
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Finish");
        destination = temp[0].GetComponent<Collider>();

        temp = GameObject.FindGameObjectsWithTag("ResourceManager");
        resources = temp[0].GetComponent<ResourceManage>();
    }
	
	// Update is called once per frame
	void Update () {
        if (destination.bounds.Intersects(myCollider.bounds))
        {
            Destroy(gameObject);
            resources.TakeDamage(10);
        }
	}
}
