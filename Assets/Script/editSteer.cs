using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class editSteer : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    Socket sck;
    //use for find the image center point
    RectTransform rect;
    Vector2 centerPoint;
    //ends here
    private float fDestroyTime = 0.3f;
    private float fTickTime;



    //to find whether the wheel is held or not
    bool wheelBeingHeld = false;
    private float wheelPrevAngle = 0f;
    private float wheelAngle = 0f;
    private bool dirLeft = false;
    private bool dirRight = false;
    //ends here

    float maximumSteeringAngle = 200f;
    float wheelReleasedSpeed = 250f;
    
    //url 
    /*public string Url;
    public string right_on;
    public string right_off;
    public string left_on;
    pulic string left_off;*/

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        getcenterPoint();
        /*Url = "http://18.179.74.220:8000";
        right_on = "/vicer/right_on";
        right_off = "/vicer/right_off";
        left_on = "/vicer/left_on";
        left_off = "/vicer/left_off";*/
        StartCoroutine(Wait());
        
    }


    private void Update()
    {
        fTickTime += Time.deltaTime;
        if (fTickTime >= fDestroyTime)
        {
            if (!wheelBeingHeld && !Mathf.Approximately(0f, wheelAngle))
            {
                float deltaAngle = wheelReleasedSpeed * Time.deltaTime;
                if (Mathf.Abs(deltaAngle) > Mathf.Abs(wheelAngle))
                    wheelAngle = 0f;
                else if (wheelAngle > 0f)
                    wheelAngle -= deltaAngle;
                else
                    wheelAngle += deltaAngle;
            }

            // Rotate the wheel image
            rect.localEulerAngles = new Vector3(0, 0, -1) * wheelAngle;
            
            if (wheelAngle > 30)
            {

                StartCoroutine(ROn());
                //Debug.Log("Right on");
                dirRight = true;

            }
            else if (wheelAngle < -30)
            {
                StartCoroutine(LOn());
                //Debug.Log("Left on");
                dirLeft = true;
            }
            else if (wheelAngle < 5 && wheelAngle > -5)
            {
                if (dirLeft)
                {
                    StartCoroutine(LOff());
                    //Debug.Log("Left off");
                    dirLeft = false;
                }
                else if (dirRight)
                {
                    StartCoroutine(ROff());
                    //Debug.Log("Right off");
                    dirRight = false;
                }
            }
        }
    }

    // to calculate the center of the image
    private void getcenterPoint()
    {    //to get the position of the corners of the image in the world
        Vector3[] corners = new Vector3[4];
        rect.GetWorldCorners(corners);
        // end here

        for (int i = 0; i < 4; i++)
        {
            corners[i] = RectTransformUtility.WorldToScreenPoint(null, corners[i]);
        }

        Vector3 bottomLeft = corners[0];
        Vector3 topRight = corners[2];
        float width = topRight.x - bottomLeft.x;
        float height = topRight.y - bottomLeft.y;

        Rect _rect = new Rect(bottomLeft.x, topRight.y, width, height);
        centerPoint = new Vector2(_rect.x + _rect.width * 0.5f, _rect.y - _rect.height * 0.5f);
    }
    //end here and we get overselves the  centerpoint of the rect image which is stored in the centerPoint



    //for the events
    //IpointerDownHandler , IDragHandler ,   IPointerUpHandler

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 pointerPos = ((PointerEventData)eventData).position;
        wheelBeingHeld = true;
        wheelPrevAngle = Vector2.Angle(Vector2.up, pointerPos - centerPoint);

    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pointerPos = ((PointerEventData)eventData).position;

        float wheelNewAngle = Vector2.Angle(Vector2.up, pointerPos - centerPoint);



        // Do nothing if the pointer is too close to the center of the wheel
        if (Vector2.Distance(pointerPos, centerPoint) > 20f)
        {
            if (pointerPos.x > centerPoint.x)
                wheelAngle += wheelNewAngle - wheelPrevAngle;
            else
                wheelAngle -= wheelNewAngle - wheelPrevAngle;
        }
        // Make sure wheel angle never exceeds maximumSteeringAngle
        wheelAngle = Mathf.Clamp(wheelAngle, -maximumSteeringAngle, maximumSteeringAngle);
        wheelPrevAngle = wheelNewAngle;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnDrag(eventData);
        wheelBeingHeld = false;
    }
    //end of the eventHandlers here



    //전송 코루틴
    /*IEnumerator RightOn()
    {
        WWWForm form = new WWWForm();
        WWW webRequset = new WWW(Url + right_on);
        yield return webRequset;
        Debug.Log("Response from http for accel:" + webRequset.text);
    }
    IEnumerator RightOff()
    {
        WWWForm form = new WWWForm();
        WWW webRequset = new WWW(Url + right_off);
        yield return webRequset;
        Debug.Log("Response from http for accel:" + webRequset.text);
    }
    IEnumerator LeftOn()
    {
        WWWForm form = new WWWForm();
        WWW webRequset = new WWW(Url + left_on);
        yield return webRequset;
        Debug.Log("Response from http for accel:" + webRequset.text);
    }
    IEnumerator LeftOff()
    {
        WWWForm form = new WWWForm();
        WWW webRequset = new WWW(Url + left_off);
        yield return webRequset;
        Debug.Log("Response from http for accel:" + webRequset.text);
    }*/
    IEnumerator ROn()
    {
        string text = "R";
        byte[] data = Encoding.UTF8.GetBytes(text);
        Debug.Log("R on");
        sck.Send(data);
        yield return null;
    }
    IEnumerator ROff()
    {
        string text = "S";
        byte[] data = Encoding.UTF8.GetBytes(text);
        Debug.Log("R off");
        sck.Send(data);
        yield return null;
    }
    IEnumerator LOn()
    {
        string text = "L";
        byte[] data = Encoding.UTF8.GetBytes(text);
        Debug.Log("L on");
        sck.Send(data);
        yield return null;
    }
    IEnumerator LOff()
    {
        string text = "S";
        byte[] data = Encoding.UTF8.GetBytes(text);
        Debug.Log("L off");
        sck.Send(data);
        yield return null;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("52.79.181.10"), 5001);
        Debug.Log("conneting steer server...");
        sck.Connect(localEndPoint);
        Debug.Log("connetion steer");
        string text = "R";
        byte[] data = Encoding.UTF8.GetBytes(text);
        sck.Send(data);
    }




}