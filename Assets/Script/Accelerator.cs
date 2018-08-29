using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class Accelerator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //bool check = false;
    public string Url;
	public string accel_on;
    public string accel_off;
    Socket sck;


    void Start() {
        //Url = "http://18.179.74.220:8000";
        //accel_on = "/vicer/accel_on";
        //accel_off = "/vicer/accel_off";  http 방식
        StartCoroutine(Wait());
        

    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("엑셀 다운");

        StartCoroutine(AccelOn());
        //check = true;
        //StartCoroutine(AcceleratorOn());
    }

    public void OnPointerUp(PointerEventData eventData)

    // 포인터가 Up될 때 호출된다. 버튼이라면 버튼이 올라오는 순간 한번 호출되는 함수
    {
        Debug.Log("엑셀 업");
        StartCoroutine(AccelOff());
        //check = false;
        //StartCoroutine(AcceleratorOff());
    }

    

    void Update() {
        

    }

    
    /* //* http 통신으로 보내는 코루틴들
    IEnumerator AcceleratorOn()
    {
        WWWForm form = new WWWForm();
        WWW webRequset = new WWW(Url + accel_on);
        yield return webRequset;
        Debug.Log("Response from http for accel:" + webRequset.text);
    }

    IEnumerator AcceleratorOff()
    {
        WWWForm form = new WWWForm();
        WWW webRequset = new WWW(Url + accel_off);
        yield return webRequset;
        Debug.Log("Response from http for accel:" + webRequset.text);
    }
    */
    IEnumerator AccelOn()
    {
        string text = "F";
        byte[] data = Encoding.UTF8.GetBytes(text);
        sck.Send(data);
        yield return null;
    }
    IEnumerator AccelOff()
    {
        string text = "S";
        byte[] data = Encoding.UTF8.GetBytes(text);
        sck.Send(data);
        yield return null;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("52.79.181.10"), 5001);
        Debug.Log("conneting accel server...");
        sck.Connect(localEndPoint);
        Debug.Log("connetion accel");
        string text = "F";
        byte[] data = Encoding.UTF8.GetBytes(text);
        sck.Send(data);
    }
}

