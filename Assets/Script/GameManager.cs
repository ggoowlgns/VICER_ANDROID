using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public static string BackBtn;

    public Canvas Main_Canvas; // 메인창
    public Canvas screen2_canvas; // 회원가입
    public Canvas screen3_canvas; // 고객이 대리기사 메시지보내는 창
    public Canvas screen4_canvas; // 시리얼 확인 창
    public Canvas screenBT_canvas; // 블루투스 선택창
    public Canvas ScreenNoti_canvas;
    //public Canvas screen5_canvas;

    public CanvasGroup Main;
    public CanvasGroup screen2;
    public CanvasGroup screen3;
    public CanvasGroup screen4;
    public CanvasGroup screenBT;
    public CanvasGroup screenNoti;
    //public CanvasGroup screen5;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
 
        Main.alpha = 1;
        Main_Canvas.enabled = true;

        screen2.alpha = 0; // 투명도
        screen2_canvas.enabled = false;// 상호작용 불허

        screen3.alpha = 0; // 투명도
        screen3_canvas.enabled = false;// 상호작용 불허

        screen4.alpha = 0; // 투명도
        screen4_canvas.enabled = false;// 상호작용 불허

        screenBT.alpha = 0; // 투명도
        screenBT_canvas.enabled = false;// 상호작용 불허

        BackBtn = "Main";
    }
   
    public void Main_Active() { // 메인화면으로
        Main.alpha = 1;
        Main.interactable = true;
        Main_Canvas.enabled = true;
        screen2_canvas.enabled = false;
        screen3_canvas.enabled = false;
        screen4_canvas.enabled = false;
        screenBT_canvas.enabled = false;
        BackBtn = "Main";
    }

    public void Screen2_Active() //  회원가입으로
    {
        screen2.alpha = 1;
        screen2.interactable = true;
        screen2_canvas.enabled = true;
        Main_Canvas.enabled = false;
        BackBtn = "Screen2";
    }
    
    public void Screen3_Active() // 고객메뉴얼 창으로
    {
        screen3.alpha = 1;
        screen3.interactable = true;
        screen3_canvas.enabled = true;
        Main_Canvas.enabled = false;
        BackBtn = "Screen3";
    }
    
    public void Screen4_Active() // 시리얼을 체크하는 창
    {
        screen4.alpha = 1;
        screen4.interactable = true;
        screen4_canvas.enabled = true;
        Main_Canvas.enabled = false;
        BackBtn = "Screen4";
    }

    public void ScreenBT_Active() // BT설정창으로
    {
        screenBT.alpha = 1;
        screenBT.interactable = true;
        screenBT_canvas.enabled = true;
        screen4_canvas.enabled = false;
        
        BackBtn = "ScreenBT";
    }

}
