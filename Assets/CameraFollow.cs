using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // Use this for initialization
    Vector3 targetCamPos;

    public float smoothing = 5f;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        targetCamPos.Set(-1*h, 0f, -1*v);

        targetCamPos = targetCamPos.normalized;

        transform.position = Vector3.Lerp(transform.position, transform.position + targetCamPos, smoothing * Time.deltaTime);
    }
}
