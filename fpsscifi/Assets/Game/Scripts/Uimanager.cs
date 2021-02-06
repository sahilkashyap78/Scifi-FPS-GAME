using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uimanager : MonoBehaviour {
    [SerializeField] Text ammo_text;

	public void updateAmmo(int ammo)
    {
        ammo_text.text = "Ammo:" + ammo;

    }
}
