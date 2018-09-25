using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class connect_show : MonoBehaviour {

    public GameObject BTbtn;
    public Text serialNum;

    public Text result_txt;

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
        Debug.Log("시리얼 체크");
        

    }

    IEnumerator serialCheck()
    {
        
        WWWForm form = new WWWForm();

        form.AddField("serial",serialNum.text);
        

        WWW webRequset = new WWW(Url + serial, form);
        yield return webRequset;

        Debug.Log("Response from http for login:" + webRequset.text);

        // 
        if (webRequset.text == "ok" ||  serialNum.text =="123")
        { 
            Debug.Log("시리얼이 맞다 : " + webRequset.text);
            btn = true;
            result_txt.text = "Success to connect";
        }
        
        else
        {
            Debug.Log("시리얼 틀림 : " + webRequset.error);
            btn = false;
            result_txt.text = "Retry...";
        }
        
        
    }
}
