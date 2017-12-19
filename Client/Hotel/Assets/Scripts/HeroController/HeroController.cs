using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {
    private Animator animator;
    private List<Sprite> heroSprites;

	// Use this for initialization
	void Start () {
        this.animator = GetComponent<Animator>();

        heroSprites = new List<Sprite>(Resources.LoadAll<Sprite>("Sprites/Hero001"));

        Debug.Log(heroSprites.Count);
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
