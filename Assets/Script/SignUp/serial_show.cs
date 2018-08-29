using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class serial_show : MonoBehaviour {

    public GameObject serial_input;
    public CanvasGroup onButton;

    void Start () {
        
	}

	void Update () {
        if (onButton.alpha == 0)
        {
            serial_input.SetActive(true);
        }
        else {
            serial_input.SetActive(false);
        }

    }
}
