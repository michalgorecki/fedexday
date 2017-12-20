using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	private string timerMessage = "Left from WLA: ";
	public const int FONT_SIZE = 20;
	public bool WLA_MISSED = false;
	float timer = 1.0f;
	public GUIStyle myStyle = new GUIStyle();




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
	{   myStyle.alignment = TextAnchor.LowerCenter;
		myStyle.fontSize = FONT_SIZE;
		if (WLA_MISSED) {
			myStyle.normal.textColor = Color.red;
			GUI.skin.textArea.alignment = TextAnchor.MiddleCenter;
			GUI.Box (new Rect (100, 20, 300, 50), timerMessage + (int)timer, myStyle);

		} else {
			GUI.Box (new Rect (100, 20, 300, 50), timerMessage + (int)timer,myStyle);
		}
	}
}
