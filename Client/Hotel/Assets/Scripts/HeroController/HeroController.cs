using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {
    private Animator animator;

	// Use this for initialization
	void Start () {
        Debug.Log("isWork" + animator.GetBool("isWalk"));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("isWalk", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isWalk", false);
        }
	}
}
