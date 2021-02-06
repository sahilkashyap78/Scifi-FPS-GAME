using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour {
    [SerializeField] float mousesensitivity = 3f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveX();
	}

    void MoveX()
    {

        float mouseX = Input.GetAxis("Mouse X");
        Vector3 _newrotation = transform.localEulerAngles;
        _newrotation.y += mouseX * mousesensitivity;
        transform.localEulerAngles = _newrotation;

    }
}
