using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBillboard : MonoBehaviour {

    public GameObject mainCamera;

	void Start () {  
		mainCamera = Camera.main.gameObject;
		this.transform.LookAt (mainCamera.transform.position);
	}  
	void Update(){  
		Vector3 v = mainCamera.transform.position - transform.position;  
		v.x = v.z = 0.0f;  
		transform.LookAt(mainCamera.transform.position - v);   
	}  
}
