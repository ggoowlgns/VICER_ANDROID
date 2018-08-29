using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//알림뷰의 표시옵션 지정 클래스
public class AlertViewOptions {
    //취소버튼이름
    public string cancelButtonTitle;
    //취소버튼 누르면 실행되는 대리자
    public System.Action cancelButtonDelegate;
    //ok버튼 타이틀
    public string okButtonTitle;
    //ok누르면 실행되는 대리자
    public System.Action okButtonDelegate;
}
public class AlertViewController : MonoBehaviour {
    //타이틀 표시
    public Text titleLabel;
    //메시지 표시
    public Text messageLabel;
    //오케이 버튼 
    public Button okButton;
    //취소버튼
    public Button cancelButton;
    //오케이버튼 타이틀
    public Text okButtonLabel;
    //취소버튼 타이틀
    public Text cancelButtonLabel;

    private static GameObject prefab;
    // 취소버튼 클릭시 실행되는 대리자
    private System.Action cancelButtonDelegate;
    //오케이 버튼 클릭시 실해되는 대리자
    private System.Action okButtonDelegate;


    //알림뷰 표시하는 static 메서트
    public static AlertViewController Show(string title, string message, AlertViewOptions options = null) {
        if (prefab == null) {
            //프리팹 읽기
            prefab = Resources.Load("AlertView") as GameObject;
        }

        GameObject go = Instantiate(prefab) as GameObject;
        AlertViewController alertView = go.GetComponent<AlertViewController>();
        alertView.UpdateContent(title, message, options);

        return alertView;
    }
    
    //알림뷰의 내용 갱신 메서드
    public void UpdateContent(string title, string message, AlertViewOptions options= null) {
        titleLabel.text = title;
        messageLabel.text = message;

        if (options != null)
        {
            cancelButton.transform.gameObject.SetActive(options.cancelButtonTitle != null || options.okButtonTitle != null);

            cancelButton.gameObject.SetActive(options.cancelButtonTitle != null);
            cancelButtonLabel.text = options.cancelButtonTitle ?? "";
            cancelButtonDelegate = options.cancelButtonDelegate;

            okButton.gameObject.SetActive(options.okButtonTitle != null);
            okButtonLabel.text = options.okButtonTitle ?? "";
            okButtonDelegate = options.okButtonDelegate;
        }
        else {
            cancelButton.gameObject.SetActive(false);
            okButton.gameObject.SetActive(true);
            okButtonLabel.text = "OK";
        }
    }
    //알림뷰를 닫는 메소드
    public void Dismiss() {
        Destroy(gameObject);
    }

    public void OnPressCancelButton() {
        if (cancelButtonDelegate != null) {
            cancelButtonDelegate.Invoke();
        }
        Dismiss();
    }
    public void OnPressOkButton()
    {
        if (okButtonDelegate != null)
        {
            okButtonDelegate.Invoke();
        }
        Dismiss();
    }

}
