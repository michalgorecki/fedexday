using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	private string timerMessage = "Left from WLA: ";
	private bool WLA_MISSED = false;
	float timer = 5.0f;

	void Update()
	{
		if (timer < 0 && !WLA_MISSED) {
			WLA_MISSED = true;
			timerMessage = "Missed WLA: ";
		}
		timer = timer - Time.deltaTime;

	}

	void OnGUI()
	{
		GUI.Box (new Rect (100, 100, 300, 50), timerMessage + (int)timer);
	}
}
