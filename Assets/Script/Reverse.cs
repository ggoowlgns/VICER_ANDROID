using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class Reverse : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //bool check = false;
    public string Url;
    public string reverse_on;
    public string reverse_off;
    Socket sck;

    void Start()
    {
        /*Url = "http://18.179.74.220:8000";
        reverse_on = "/vicer/reverse_on";
        reverse_off = "/vicer/reverse_off";*/
        StartCoroutine(Wait());

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("후진 다운");
        StartCoroutine(ReverOn());
        //check = true;
        //StartCoroutine(ReverseOn());
    }

    public void OnPointerUp(PointerEventData eventData)

    // 포인터가 Up될 때 호출된다. 버튼이라면 버튼이 올라오는 순간 한번 호출되는 함수
    {
        Debug.Log("후진 업");
        StartCoroutine(ReverOff());
        //check = false;
        //StartCoroutine(ReverseOff());
    }



    void Update()
    {

    }


    /*IEnumerator ReverseOn()
    {
        WWWForm form = new WWWForm();
        WWW webRequset = new WWW(Url + reverse_on);
        yield return webRequset;
        Debug.Log("Response from http for accel:" + webRequset.text);
    }

    IEnumerator ReverseOff()
    {
        WWWForm form = new WWWForm();
        WWW webRequset = new WWW(Url + reverse_off);
        yield return webRequset;
        Debug.Log("Response from http for accel:" + webRequset.text);
    }*/
    IEnumerator ReverOn()
    {
        string text = "B";
        byte[] data = Encoding.UTF8.GetBytes(text);
        sck.Send(data);
        yield return null;
    }
    IEnumerator ReverOff()
    {
        string text = "S";
        byte[] data = Encoding.UTF8.GetBytes(text);
        sck.Send(data);
        yield return null;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("52.79.181.10"), 5001);
        Debug.Log("conneting reverse server...");
        sck.Connect(localEndPoint);
        Debug.Log("connetion reverse");
        string text = "B";
        byte[] data = Encoding.UTF8.GetBytes(text);
        sck.Send(data);
    }
}

