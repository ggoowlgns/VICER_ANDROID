using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class connect_show : MonoBehaviour {

    public GameObject BTbtn;
    public Text serialNum;

    private string Url;
    private string serial;
    private bool btn = false;

    void Start () {
        Url = "http://18.179.74.220:8000";
        serial = "/members/serial";
        BTbtn.SetActive(false);
    }

    void Update () {
        if (btn)
        {
            BTbtn.SetActive(true);
        }
        else
        {
            BTbtn.SetActive(false);
        }
    }

    public void serialCehck()
    {
        StartCoroutine(serialCheck());
        Debug.Log("로그인");
        

    }

    IEnumerator serialCheck()
    {
        
        WWWForm form = new WWWForm();

        form.AddField("serial",serialNum.text);
        

        WWW webRequset = new WWW(Url + serial, form);
        yield return webRequset;

        Debug.Log("Response from http for login:" + webRequset.text);

        // 
        if (true)
        {
            Debug.Log("시리얼이 맞다 : " + webRequset.text);
            btn = true;
        }
        /*
        else
        {
            Debug.Log("시리얼 틀림 : " + webRequset.error);
            btn = false;

        }
        */
        
    }
}
