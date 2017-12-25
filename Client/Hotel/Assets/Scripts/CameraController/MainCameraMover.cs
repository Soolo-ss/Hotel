using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMover : MonoBehaviour {
    public Transform target;
    public static float offset = 1.0f;
	private float smoothTime = 0.1f;
	private Vector3 cameraVelocity = Vector3.zero;
	private Vector3 firstOffsetVec = new Vector3 (0, Mathf.Sqrt (offset / 3f), offset);
	private Vector3 offsetVec = new Vector3();

	// Use this for initialization
	void Start () {
		this.transform.position = target.transform.position + firstOffsetVec;
		offsetVec = firstOffsetVec;
	}

    // Update is called once per frame
    void Update()
    {
		//Vector3 offsetVec = new Vector3 (0, Mathf.Sqrt (offset / 3f), offset);
		//transform.position = Vector3.SmoothDamp (transform.position, target.position + offsetVec, ref cameraVelocity, 0);

		this.transform.position = target.transform.position + offsetVec;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.transform.RotateAround(target.transform.position, Vector3.up, 90f);
			offsetVec = this.transform.position - target.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            this.transform.RotateAround(target.transform.position, Vector3.up, -90f);
			offsetVec = this.transform.position - target.transform.position;
        }

        this.transform.LookAt(target);
		target.transform.LookAt (this.transform);
    }
}
