using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    CharacterController _controller;
    private float ammotimer = 0f;
    [SerializeField]GameObject muzzleflash;
    [SerializeField] GameObject hitmaker;
    [SerializeField] float speed = 3.5f;
    [SerializeField] AudioSource shotclip;
    [SerializeField] int currentammo=0;
    Uimanager _uimanager;
    int maxammo = 50;
    float gravity = 9.81f;
	// Use this for initialization
	void Start () {
        muzzleflash.SetActive(false);
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        currentammo = maxammo;
        _uimanager = GameObject.Find("Canvas").GetComponent<Uimanager>();
    }
	
	// Update is called once per frame
	void Update () {

        //for shooting of weapons and setingup the raycast

       
        if(Input.GetMouseButtonDown(1))
        {
            currentammo = maxammo;
            _uimanager.updateAmmo(currentammo);
        }

        if (Input.GetMouseButton(0)&&currentammo>0)
        {
            currentammo--;
            _uimanager.updateAmmo(currentammo);
            shoot();

        }
        else
        {
            shotclip.Stop();
            muzzleflash.SetActive(false);
        }

        

        //press escape to get the cursor back
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        //player Movement
        charmovement();    

	}



    void shoot()
    {

        if(shotclip.isPlaying==false)
        {
            shotclip.Play();
        }


        muzzleflash.SetActive(true);
        Ray rayorigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        RaycastHit hitinfo;
        if (Physics.Raycast(rayorigin, out hitinfo))
        {
            Debug.Log("Hit" + hitinfo.transform.name);
            GameObject hitmarker = Instantiate(hitmaker, hitinfo.point, Quaternion.identity);
            Destroy(hitmarker, 1f);
        }



    }



    void charmovement()
    {

        float horizontalmov = Input.GetAxis("Horizontal");
        float verticalmov = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalmov, 0, verticalmov);
        Vector3 velocity = direction * speed;
        velocity.y -= gravity;
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);


    }


}
