using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VR_scene : MonoBehaviour {

    
    // Use this for initialization
    void Start() {
        XRSettings.enabled = false;
    }
    public void nextScene() {
        Debug.Log("VR로 넘어가기");
        XRSettings.enabled = true;
        Application.LoadLevel("test");
    }
}
