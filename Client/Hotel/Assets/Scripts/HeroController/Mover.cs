﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	private CharacterController character;
	private Animator animator;

	private List<KeyCode> runKey = new List<KeyCode>() { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
	private float speed = 0.5f;
	private float gravity = 1.0f;
	private Transform mainCamera;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start ()
    {
		this.animator = GetComponent<Animator>();
		this.character = GetComponent<CharacterController> ();
		this.mainCamera = Camera.main.transform;
	}

	// Update is called once per frame
	void Update ()
    {
		move ();
	}

	void FixedUpdate()
    {
		moveDirection = new Vector3 (-Input.GetAxis ("Horizontal"), 0, -Input.GetAxis ("Vertical"));
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= speed;

		moveDirection.y = -gravity;

		if (moveDirection != Vector3.zero) {
			character.Move (moveDirection * Time.deltaTime);
		}
	}

	private bool GetRunKeyDown()
    {
		bool isRun = false;
		foreach (KeyCode key in runKey) {
			if (Input.GetKeyDown (key)) {
				isRun = true;
				break;
			}
		}

		return isRun;
	}

	private bool GetRunKeyUp(ref KeyCode upKey)
    {
		bool isUp = false;
		foreach (KeyCode key in runKey) {
			if (Input.GetKeyUp (key)) {
				isUp = true;
                upKey = key;
				break;
			}
		}

		return isUp;
	}

    private bool isOtherRunKeyDown(KeyCode upKey)
    {
        bool isDown = false;

        foreach(KeyCode key in runKey)
        {
            if (Input.GetKey(key) && key != upKey)
            {
                isDown = true;
                break;
            }
        }

        return isDown;
    }

	
	public void move()
	{
		if (GetRunKeyDown ()) {
			animator.SetBool ("isRun", true);

			if (Input.GetKeyDown (KeyCode.W)) {
				moveUpClip ();
			} else if (Input.GetKeyDown (KeyCode.S)) {
				moveDownClip ();
			} else if (Input.GetKeyDown (KeyCode.A)) {
				moveLeftClip ();
			} else if (Input.GetKeyDown (KeyCode.D)) {
				moveRightClip ();
			}
		}

        KeyCode upKey = new KeyCode(); ;
		if (GetRunKeyUp(ref upKey) && !isOtherRunKeyDown(upKey)){
			animator.SetBool ("isRun", false);

			if (Input.GetKeyUp (KeyCode.W)) {
				moveUpClip ();
			} else if (Input.GetKeyUp (KeyCode.S)) {
				moveDownClip ();
			} else if (Input.GetKeyUp (KeyCode.A)) {
				moveLeftClip ();
			} else if (Input.GetKeyUp (KeyCode.D)) {
				moveRightClip ();
			}
		}
	}

	private void moveUpClip() {
		animator.SetFloat ("xdir", 0);
		animator.SetFloat ("ydir", 1);
	}

	private void moveDownClip() {
		animator.SetFloat ("xdir", 0);
		animator.SetFloat ("ydir", -1);
	}

	private void moveLeftClip() {
		animator.SetFloat ("xdir", -1);
		animator.SetFloat ("ydir", 0);
	}

	private void moveRightClip() {
		animator.SetFloat ("xdir", 1);
		animator.SetFloat ("ydir", 0);
	}
}
