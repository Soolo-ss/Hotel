using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBillboard : MonoBehaviour {

    public GameObject mainCamera;

	void Start () {  
		mainCamera = Camera.main.gameObject;
	}  
	void LateUpdate(){  
		//Vector3 forward = mainCamera.transform.forward;
		//this.transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);

        //if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        //{
        //    Vector3 lookPoint = mainCamera.transform.position;
        //    lookPoint.y = this.transform.position.y;

        //    transform.LookAt(lookPoint);
        //}

        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.transform.Rotate(0, 90, 0, Space.Self);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            this.transform.Rotate(0, -90, 0, Space.Self);
        }
    } 
}
