using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class serial_show : MonoBehaviour {

    public Toggle check;
    public GameObject si; // Serial Inputfield

    
    void Start () {
            
	}

	void Update () {
        //Debug.Log("check :", check);
        if (check.isOn)
        {
            //Debug.Log("check : ok");
            si.SetActive(true);
        }
        else {
            //si.alpha = 0;
            //Debug.Log("check : NO");
            si.SetActive(false);
        }

    }
}
