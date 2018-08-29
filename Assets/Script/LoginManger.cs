using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoginManger : MonoBehaviour 
{

    [Header("LoginPanel")]
    public InputField id_Login;
    public InputField pswd_Login;
    public string Url;
    public string Login;
    public Text id;
    //private bool login = false;

    [Header("SignupPanel")]
    public Text _id ;
    public Text _pswd ;
    public Text _grade ;

    void Start()
    {       
        Url = "http://18.179.74.220:8000";
        Login = "/members/login";
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
        //StartCoroutine(LoginGo());
        Debug.Log("로그인");
        if (id.text == "123")
        {
            StartCoroutine(DoFadeMember());
        }
        else
        {
            StartCoroutine(DoFadeDriver());
        }


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

        Debug.Log("Response from http for login:" + webRequset.text);

        // 
        if (true)
        {
            Debug.Log("로그인성공 : " + webRequset.text);
            //StartCoroutine(DoFade());
        }
        /*
        else
        {
            Debug.Log("error : " + webRequset.error);
            FailLoginAlert();
        }
        */
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
