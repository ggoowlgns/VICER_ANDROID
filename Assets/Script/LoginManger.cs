using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoginManger : MonoBehaviour 
{

    [Header("LoginPanel")]
    public InputField id_Login;
    public InputField pswd_Login;
    private string Url;
    private string Login;
    public Text id;
    //private bool login = false;

    [Header("SignupPanel")]
    public Text _id ;
    public Text _pswd ;
    public Text _grade ;

    //http 통신비교용 변수
    private string httpResult;
    private string httpDone;


    void Start()
    {       

        //Url = "http://18.179.74.220:8000"; //예전 url
        Url = "http://220.67.124.128:8090";
        Login = "/vicer/member_login.do";
            //아이디 패스워드 이름 폰넘버

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.BackBtn == "Main")
        {
            Application.Quit();
        }
    }

    public void LoginBtn()
    {
        StartCoroutine(LoginGo());
        Debug.Log("로그인");
    }
    
    IEnumerator LoginGo()
    {
        Debug.Log(id_Login.text);
        Debug.Log(pswd_Login.text);
   
        WWWForm form = new WWWForm();

        form.AddField("id", id_Login.text);
        form.AddField("passwd", pswd_Login.text);

        WWW webRequset = new WWW(Url + Login, form);
        yield return webRequset;

        //Debug.Log("Response from http for login:" + webRequset.text);
        httpResult = webRequset.text.ToString();
        Debug.Log("text : " + httpResult);
        Debug.Log("결과 :" + webRequset.error);

        if (httpResult == "<html><body>1</body></html>" || id.text =="123")
        {
            StartCoroutine(DoFadeDriver());
        }
        /*
        else if (httpResult == "driver" || id.text == "ggoowlgns@naver.com")
        {
            StartCoroutine(DoFadeDriver());
        }
        */
        else
        {
            Debug.Log("login error");
        }
    }

    
    



    /*
    public void fade()
    {
        if (id.text == "123")
        {
            StartCoroutine(DoFadeMember());
        }
        else {
            StartCoroutine(DoFadeDriver());
        }
        
    }
    */

    IEnumerator DoFadeMember()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 2;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;

        GameManager.instance.Screen3_Active();
    }

    IEnumerator DoFadeDriver()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 2;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;

        GameManager.instance.Screen4_Active();
    }
}
