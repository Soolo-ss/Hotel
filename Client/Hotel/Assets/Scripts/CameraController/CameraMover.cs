using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

    private Vector3 rotationAngle = new Vector3(0f, 90f, 0f);
    public GameObject hero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 center = this.transform.position;
        center.x = hero.transform.position.x;
        center.z = hero.transform.position.z;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.transform.position = PointRotateWithXZPlane(center, this.transform.position, 90f);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            this.transform.position = PointRotateWithXZPlane(center, this.transform.position, -90f);
        }
	}

    private Vector3 PointRotateWithXZPlane(Vector3 center, Vector3 source, float angle)
    {
        Vector3 temp = new Vector3();

        float angleHude = angle * Mathf.PI / 180;
        float x1 = (source.x - center.x) * Mathf.Cos(angleHude) + (source.z - center.z) * Mathf.Sin(angleHude) + center.x;
        float z1 = -(source.x - center.x) * Mathf.Sin(angleHude) + (source.z - center.z) * Mathf.Cos(angleHude) + center.z;

        temp.x = x1;
        temp.y = source.y;
        temp.z = z1;

        return temp;
    }
}
