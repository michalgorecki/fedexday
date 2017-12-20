using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeePower : MonoBehaviour {
	public Image caffeeMeter;
	public float playerCoffeeLevel;
	// Use this for initialization
	void Start () {
		playerCoffeeLevel = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateCoffeeMeter(float f){
		playerCoffeeLevel = Mathf.Clamp (playerCoffeeLevel + f, 0.0f, 1.0f);
		if (caffeeMeter != null) {
			caffeeMeter.fillAmount = playerCoffeeLevel / 1.0f;
		}
	}
}
