using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // Use this for initialization
    Vector3 targetCamPos;

    public float smoothing = 5f;


    void Awake () {

    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Debug.Log("camera position, x: " + transform.position.x.ToString() + " y: " + transform.position.y.ToString() + " z: " + transform.position.z.ToString());

        targetCamPos.Set(-1*h, 0f, -1*v);

        targetCamPos = targetCamPos.normalized;

        if (transform.position.x <= 5 || transform.position.x >= 50 || transform.position.z <= 5 || transform.position.z >= 50)
        {
            // do something.
        }
        else
        {

        }

        transform.position = Vector3.Lerp(transform.position, transform.position + targetCamPos, smoothing * Time.deltaTime);
    }


}
