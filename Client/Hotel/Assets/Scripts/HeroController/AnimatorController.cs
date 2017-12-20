using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {
    private Animator animator;
	private List<KeyCode> runKey = new List<KeyCode>() { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
	private int moveSpeed = 1;

	// Use this for initialization
	void Start () {
        this.animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

		move ();
	
	}

	private bool GetRunKeyDown(){
		bool isRun = false;
		foreach (KeyCode key in runKey) {
			if (Input.GetKeyDown (key)) {
				isRun = true;
				break;
			}
		}

		return isRun;
	}

	private bool GetRunKeyUp(){
		bool isUp = false;
		foreach (KeyCode key in runKey) {
			if (Input.GetKeyUp (key)) {
				isUp = true;
				break;
			}
		}

		return isUp;
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

		if (GetRunKeyUp()){
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

	private void moveCalc() {
		
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

	private void cancelClip() {
		animator.SetFloat ("xdir", 0);
		animator.SetFloat ("ydir", 0);
	}

}
