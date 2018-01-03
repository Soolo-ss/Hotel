using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUIController : MonoBehaviour {

    private Button startBtn;
    private Button saveBtn;
    private Button exitBtn;

	// Use this for initialization
	void Start () {
        startBtn = this.transform.GetChild(1).GetComponent<Button>();
        saveBtn = this.transform.GetChild(2).GetComponent<Button>();
        exitBtn = this.transform.GetChild(3).GetComponent<Button>();

        startBtn.onClick.AddListener(() =>
        {
            Debug.Log("load loading scence");
            SceneManager.LoadScene("Loading");
        });

        saveBtn.onClick.AddListener(() =>
        {
            
        });

        exitBtn.onClick.AddListener(() =>
        {

        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
