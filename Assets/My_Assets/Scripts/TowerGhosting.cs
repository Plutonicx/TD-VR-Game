using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGhosting : MonoBehaviour {

    Vector3 targetCamPos;
    Transform ghostTowerTransform;

    public GameObject tower;

    int floorMask;
    float camRayLength = 100f;

    // Use this for initialization
    void Awake () {
        floorMask = LayerMask.GetMask("Floor");
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost"); //TODO: On fixed update search for ghost towers.
        ghostTowerTransform = ghosts[0].GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

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


            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(tower, ghostTowerTransform.position, ghostTowerTransform.rotation);
            }

        }

    }

}
