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

    [Header("job toggle ")]
    public Toggle check;
    // 회원가입완료시 나오게 될 안내창의 텍스트 메시지
    public Text alertBody;

    // http 통신에 사용할 주소
    private string Url;
    private string SignUp;

    // 직업이 무엇인지 확인하기 위한 필드
    public CanvasGroup onButton;
    public string ocup ;

    //날짜 계산용 정수필드
    private int y;
    private int m;
    private int d;

    //http 통신결과 비교에 사용할 스트링
    private string httpResult;
    private string httpDone;

    
    void Start () {
        Url = "http://18.179.74.220:8000"; 
        //Url = "http://192.168.35.211";
        SignUp = "/vicer/reg";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.BackBtn == "Screen2")
        {
            fade();
        }

       
        if (check.enabled)
        {
            ocup = "member";
        }
        else
        {
            ocup = "driver";
        }

    
    } 
    


    public void SignupBtn()
    {

        StartCoroutine(SignupGo());
        Debug.Log("signup go");

        if (httpResult == "success")
        {
            alertBody.text = "회원가입에 성공 하셨습니다. 이제 로그인 해주시기 바랍니다.";
        }
        else
        {
            alertBody.text = "회원 가입간 오류가 발생하였습니다. 다시 시도해 주시기 바랍니다.";
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
        form.AddField("email", email_signUp.text);
        form.AddField("serialNum", car_serial_signUp.text);
        form.AddField("ocup", ocup);
        form.AddField("birth", y.ToString() +"/"+ m.ToString() +"/"+ d.ToString());
        


        WWW webRequset = new WWW(Url + SignUp, form);
        yield return webRequset;

        Debug.Log("Response from http for signup:" + webRequset.text);
        Debug.Log("Response from http for signup:" + webRequset.isDone);
        Debug.Log("Response from http for signup:" + webRequset.error);
        httpResult = webRequset.text;


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
