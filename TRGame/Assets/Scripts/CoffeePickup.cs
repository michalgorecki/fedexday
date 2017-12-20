﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeePickup : MonoBehaviour {

	public float coffeeValue;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider)	{
	
		CoffeePower c = FindObjectOfType<CoffeePower> ();
		if (c != null) {
			c.UpdateCoffeeMeter (coffeeValue);
		}

		Destroy (gameObject);
	}
}