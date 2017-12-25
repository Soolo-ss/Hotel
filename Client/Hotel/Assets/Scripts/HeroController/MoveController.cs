using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {
	private CharacterController characterController;

	private float speed = 1.0f;
	private Transform mainCameraTramnsform;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		characterController = this.GetComponent<CharacterController> ();
		mainCameraTramnsform = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection = new Vector3 (-Input.GetAxis ("Horizontal"), 0, -Input.GetAxis ("Vertical"));
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= speed;

		if (moveDirection != Vector3.zero) {
			Debug.Log (moveDirection);
			characterController.Move (moveDirection * Time.deltaTime);
		}
	}
}
