using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // Use this for initialization
    Vector3 targetCamPos;
    Vector3 outOfBoundsVector;

    public float smoothing = 5f;
    public float cameraSpeed = 2f;

    void Awake () {

    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // get input for mouse drags.

        Debug.Log("camera position, x: " + transform.position.x.ToString() + " y: " + transform.position.y.ToString() + " z: " + transform.position.z.ToString());

        targetCamPos.Set(-1*h, 0f, -1*v);

        targetCamPos = targetCamPos.normalized;

        outOfBoundsVector.Set(0, 0, 0);

        if (transform.position.x <= 8 || transform.position.x >= 35 || transform.position.z <= 5 || transform.position.z >= 48)
        {
            // do something.
            if (transform.position.x <= 8)
                outOfBoundsVector = outOfBoundsVector + new Vector3(1, 0, 0);
            if (transform.position.x >= 35)
                outOfBoundsVector = outOfBoundsVector + new Vector3(-1, 0, 0);
            if (transform.position.z <= 5)
                outOfBoundsVector = outOfBoundsVector + new Vector3(0, 0, 1);
            if (transform.position.z >= 48)
                outOfBoundsVector = outOfBoundsVector + new Vector3(0, 0, -1);



            if (outOfBoundsVector.x * targetCamPos.x + outOfBoundsVector.y * targetCamPos.y + outOfBoundsVector.z * targetCamPos.z < 0)
                targetCamPos.Set(0, 0, 0);

        }

        targetCamPos *= cameraSpeed;

        transform.position = Vector3.Lerp(transform.position, transform.position + targetCamPos, smoothing * Time.deltaTime);
    }


}
