using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class VR_show : MonoBehaviour {


    public GameObject vr_btn;
    public Text checkTxt;

    void Update()
    {
        if (checkTxt.text != "Not connect")
        {
            vr_btn.SetActive(true);
        }
        else {
            vr_btn.SetActive(false);
        }
    }


}
