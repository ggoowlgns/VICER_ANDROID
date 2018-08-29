using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignupManager : MonoBehaviour {

    [Header("SignupPanel")]
    public InputField id_signUp;
    public InputField pswd_signUp;
    public InputField email_signUp;
    public InputField car_serial_signUp;
    //public InputField cellPhone_signUp;

    [Header("DropDown Contents")]
    public Dropdown year;
    public Dropdown month;
    public Dropdown day;

    public Text alertBody;

    private string Url;
    private string SignUp;

    private int y;
    private int m;
    private int d;
    public object Pasre { get; private set; }

    void Start () {
        Url = "http://18.179.74.220:8000";
        SignUp = "/members/signup";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.BackBtn == "Screen2")
        {
            fade();
        }
    }
    


    public void SignupBtn()
    {
        StartCoroutine(SignupGo());
        Debug.Log("signup go");
        if (id_signUp.text == "123")
        {
            //SuccessSignupAlert();
            alertBody.text = "good";
        }
        else
        {
            //FailSignupAlert();
            alertBody.text = "so so";
        }

    }
    
    IEnumerator SignupGo()
    {
        //Debug.Log(id_signUp.text);
        //Debug.Log(pswd_signUp.text);
        //Debug.Log("year value : " + y);
        //Debug.Log("month value : " + m);
        //Debug.Log("day value : " + d);
        Debug.Log(y.ToString() + "/" + m.ToString() + "/" + d.ToString());
        //Debug.Log(email_signUp.text);
        //Debug.Log(cellPhone_signUp.text);

        y = year.value + 1955;
        m = month.value + 1;
        d = day .value + 1;

        
        WWWForm form = new WWWForm();

        form.AddField("id", id_signUp.text);
        form.AddField("passwd", pswd_signUp.text);
        //yyyy/mm/dd
        form.AddField("year", y.ToString() +"/"+ m.ToString() +"/"+ d.ToString());
        form.AddField("email", email_signUp.text);
        form.AddField("serial", car_serial_signUp.text);
        



        WWW webRequset = new WWW(Url + SignUp, form);
        yield return webRequset;

        Debug.Log("Response from http for signup:" + webRequset.text);

    }

    //회원가입 실패시 나오는 팝업.
    public void FailSignupAlert()
    {
        string title = "회원가입 실패...";
        string message = "다시 시도해 주세요 ㅜㅜ";

        AlertViewController.Show(title, message, new AlertViewOptions
        {
            cancelButtonTitle = "다시 시도",
            cancelButtonDelegate = () =>
            {
                Debug.Log("계속 가입하기");
            },
            //        okButtonTitle = "메인메뉴로 가기", okButtonDelegate = () =>
            //        {
            //           Debug.Log("메인메뉴버튼 누름");
            //       }
        });
    }
    //회원가입 되면 나오는 팝업.
    public void SuccessSignupAlert()
    {
        string title = "회원가입이 완료되었습니다.";
        string message = "이제 로그인이 가능합니다.";

        AlertViewController.Show(title, message, new AlertViewOptions
        {
            cancelButtonTitle = "계속",
            cancelButtonDelegate = () =>
            {
                Debug.Log("계속 가입하기");
            },
            //        okButtonTitle = "메인메뉴로 가기", okButtonDelegate = () =>
            //        {
            //           Debug.Log("메인메뉴버튼 누름");
            //       }
        });
    }

    public void fade()
    {
        StartCoroutine(DoFade());
    }


    IEnumerator DoFade()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 2;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;

        GameManager.instance.Main_Active();
    }
}
