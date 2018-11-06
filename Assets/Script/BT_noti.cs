using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BT_noti : MonoBehaviour {
	public Text checkMsg;
	public GameObject vr_btn;

	private float time = 5.0f;
	private float timeSpan = 0.0f;

	public void BTNC(){
		Invoke ("NC", 3);
	}

	public void NC(){
			//timeSpan += Time.deltaTime;
			//if (timeSpan > time) {
				vr_btn.SetActive (true);
				checkMsg.text = "Connected !";
				//break;
			//}

	}


}
