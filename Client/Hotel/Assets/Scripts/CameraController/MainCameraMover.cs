using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMover : MonoBehaviour {
    public Transform target;
    public float offset;
	private float smoothTime = 0.1f;
	private Vector3 cameraVelocity = Vector3.zero;

	// Use this for initialization
	void Start () {
        float zOffset = Mathf.Sqrt(offset / 3f);
        Vector3 offsetVec = new Vector3(0, zOffset, offset);
        this.transform.position = target.transform.position + offsetVec;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.transform.RotateAround(target.transform.position, Vector3.up, 90f);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            this.transform.RotateAround(target.transform.position, Vector3.up, -90f);
        }

		Vector3 offsetVec = new Vector3 (0, Mathf.Sqrt (offset / 3f), offset);
		transform.position = Vector3.SmoothDamp (transform.position, target.position + offsetVec, ref cameraVelocity, 0);

        this.transform.LookAt(target);
    }
}
