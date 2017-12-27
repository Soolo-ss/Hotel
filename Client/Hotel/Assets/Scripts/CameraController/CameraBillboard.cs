using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBillboard : MonoBehaviour {

    public GameObject mainCamera;

	Vector3 nowLook = new Vector3();

	void Start () {  
		mainCamera = Camera.main.gameObject;
		Debug.Log(mainCamera.transform.forward);
	}  
	void Update(){  
		Vector3 forward = mainCamera.transform.forward;

		if (forward != nowLook)
			Debug.Log(forward);

		nowLook = forward;
		this.transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);		
	} 
}
