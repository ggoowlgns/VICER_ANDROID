using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sendSMS : MonoBehaviour {
    /* 문자 보내주는 양식
    public string sms_number = "+01079122744";
    public string sms_body = "serial 123456789";
    Application.OpenURL("sms:" + number.text + "?body=" + body.text);
    */
    public Text number;
    public Text body;
    public Text status;

    private string Url;
    private string send;

    void Start () {
        Application.runInBackground = true;//?? 왜 안되지..
        Url = "http://18.179.74.220:8000";
        send = "/members/sendMsg";
        //아이디 패스워드 이름 폰넘버
    }

    public void sendMsg() // 버튼에 붙이는 함수
    {
        StartCoroutine(sendMessage());
        Debug.Log("대리기사에게 문자 보냇음!");


    }

    IEnumerator sendMessage()
    {

        WWWForm form = new WWWForm();

        form.AddField("number", number.text);
        form.AddField("body", body.text);

        WWW webRequset = new WWW(Url + send, form);
        yield return webRequset;

        Debug.Log("Response from http for login:" + webRequset.text);

        // 
        if (number.text == "123")
        {
            Debug.Log("잘 전송 됨ㅎㅎ : " + webRequset.text);
            status.text = "전송이 성공적으로 되었습니다. 운전기사의 연결을 기다려 주세요.";
        }
        
        else 
        {
            Debug.Log("전송 안댐 : " + webRequset.error);
            status.text = "전송에 실패하였습니다. 다시 확인 후 전송하여 주세요.";
        }
        

    }
}


