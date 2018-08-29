using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_scene : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }
    public void nextScene() {
        Debug.Log("VR로 넘어가기");
        Application.LoadLevel("test");
    }
}
