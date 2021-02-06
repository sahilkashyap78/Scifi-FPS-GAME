using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       MoveY();
    }

    private void MoveY()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 _rotation = transform.localEulerAngles;
        _rotation.x -= mouseY;
        transform.localEulerAngles = _rotation;
    }
}
