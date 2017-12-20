using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	private string timerMessage = "Left from WLA: ";
	public const int FONT_SIZE = 20;
	public bool WLA_MISSED = false;
	float timer = 1.0f;
	public GUIStyle myStyle;

	public  Texture2D mTexture;


	void Start(){
		Debug.Log ("Start() called!");
		mTexture = new Texture2D(1,1);
		mTexture.SetPixel (0, 0, Color.red);
		myStyle = new GUIStyle();
		myStyle.alignment = TextAnchor.MiddleCenter;
		myStyle.fontSize = FONT_SIZE;
		myStyle.normal.background = mTexture;

	}


	void Update()
	{	
		if (timer < 0 && !WLA_MISSED) {
			Debug.Log ("WLA missed!");
			WLA_MISSED = true;
			timerMessage = "Missed WLA: ";
		}
		timer = timer - Time.deltaTime;

	}

	void OnGUI()
	{   

		



		if (WLA_MISSED) {
			myStyle.normal.textColor = Color.red;
			GUI.skin.textArea.alignment = TextAnchor.MiddleCenter;
			GUI.Box (new Rect (100, 20, 300, 50), timerMessage + (int)timer, myStyle);

		} else {
			GUI.Box (new Rect (100, 20, 300, 50), timerMessage + (int)timer,myStyle);
		}
	}
}
