using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	private string timerMessage = "WLA left: ";
	//Wartość startowa dla odliczania
	private const float TOTAL_WLA = 2.0f;
	public const int FONT_SIZE = 20;
	//Pozycja boxa
	private const int X_POSITION = 310;
	private const int Y_POSITION = 40;
	//flaga dotycząca tego, czy timer przekroczył 0
	public bool WLA_MISSED = false;

	float timer = TOTAL_WLA;
	public GUIStyle myStyle;
	public Image progressBar;

	void Start(){
		Debug.Log ("Start() called!");
		myStyle = new GUIStyle();
		myStyle.alignment = TextAnchor.MiddleCenter;
		myStyle.fontSize = FONT_SIZE;


	}


	void Update()
	{	
		if (timer >= 0 && !WLA_MISSED) {
			progressBar.fillAmount = Mathf.Clamp (timer / TOTAL_WLA, 0, 1.0f);
		}
		else if (timer <= 0 && !WLA_MISSED) {
			Debug.Log ("WLA missed!");
			timerMessage = "Missed WLA: ";
			WLA_MISSED = true;
		}
		timer = timer - Time.deltaTime;

	}

	void OnGUI()
	{   
		if (WLA_MISSED) {
			progressBar.fillAmount = 1;
			progressBar.color = Color.red;
			myStyle.normal.textColor = Color.white;
			GUI.skin.textArea.alignment = TextAnchor.MiddleCenter;
			GUI.Box (new Rect (X_POSITION, Y_POSITION, 300, 50), timerMessage + (int)timer, myStyle);

		} else {
			GUI.Box (new Rect (X_POSITION, Y_POSITION, 300, 50), timerMessage + (int)timer,myStyle);
		}
	}
}
