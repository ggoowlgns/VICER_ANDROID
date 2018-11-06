using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VR_scene : MonoBehaviour {
	AndroidJavaClass unityClass;
	AndroidJavaObject unityActivity;
	AndroidJavaClass customClass;
    
    // Use this for initialization
    void Start() {
        XRSettings.enabled = false;
    }

	void nextScene() {
		
		//Application.runInBackground = true; PC에서만
		bool fail = false;

		string bundleId = "com.hufs.Vicer"; // your target bundle id
		AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");

        AndroidJavaObject launchIntent = null;
        try
		{
			launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage",bundleId);
            launchIntent.Call<AndroidJavaObject>("putExtra", "macAddress", BluetoothController.macAddress);
            
		}
		catch (System.Exception e)
		{
			fail = true;
		}

		if (fail)
		{ //open app in store
			Application.OpenURL("https://google.com");
		}
		else //open the app
			ca.Call("startActivity",launchIntent);

		up.Dispose();
		ca.Dispose();
		packageManager.Dispose();
		launchIntent.Dispose();


		Debug.Log("VR로 넘어가기");
    }
    
}
