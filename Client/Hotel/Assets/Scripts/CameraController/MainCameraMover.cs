using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMover : MonoBehaviour {
    public Transform target;
    public float offset;

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

        this.transform.LookAt(target);
    }
}
