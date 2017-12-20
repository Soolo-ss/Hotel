using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {
	private CharacterController characterController;

	private float speed = 1.0f;
	private Transform mainCameraTramnsform;

	// Use this for initialization
	void Start () {
		characterController = this.GetComponent<CharacterController> ();
		mainCameraTramnsform = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mainCameraForward = Vector3.Scale (mainCameraTramnsform.forward, new Vector3 (1, 0, 1)).normalized;

		print ("main_x" + "_" + mainCameraForward.x);
		print ("main_y" + "_" + mainCameraForward.y);
		print ("main_z" + "_" + mainCameraForward.z);

		if (Input.GetKeyDown (KeyCode.W))
			mainCameraForward = Vector3.Scale (mainCameraForward, new Vector3 (1, 1, 1)).normalized;
		else if (Input.GetKeyDown (KeyCode.A))
			mainCameraForward = Vector3.Scale (mainCameraForward, new Vector3 (-1, 1, 1)).normalized;
		else if (Input.GetKeyDown (KeyCode.D))
			mainCameraForward = Vector3.Scale (mainCameraForward, new Vector3 (1, 1, -1)).normalized;
		else if (Input.GetKeyDown (KeyCode.S))
			mainCameraForward = Vector3.Scale (mainCameraForward, new Vector3 (-1, 1, -1)).normalized;

		Debug.Log (mainCameraForward);

		this.characterController.Move (speed * mainCameraForward);
	}
}
