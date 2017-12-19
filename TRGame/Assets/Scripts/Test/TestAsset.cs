using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAsset : MonoBehaviour {

	public GameObject bulletPrefab;
	public float maxDistance;
	public float travelTime;
	public float shootInterval;
	public float rotateSpeed;
	public float shootForce;

	private Vector3 originalPosition;
	private Vector3 destination;
	private int direction = 1;// 1 - up, -1 = down
	private float startTime;
	private float shootTime;

	// Use this for initialization
	void Start () {
		ReverseDirection();
		ShootBullet ();
	}
	
	// Update is called once per frame
	void Update () {
		//1. Fly up and down
		if (Time.time > startTime + travelTime) {
			//reverse travel direction
			ReverseDirection();
		}

		float currentTime = (Time.time - startTime) / travelTime;
		transform.position = Vector3.Lerp (originalPosition, destination, currentTime);

		//2. Rotate around X
		transform.Rotate(new Vector3(0.0f, 1.0f * rotateSpeed, 0.0f));

		//3. Shoot bullets
		if (Time.time > shootTime + shootInterval) {
			//Create new bullet
			GameObject bullet = GameObject.Instantiate (bulletPrefab);
			//Move it to our cube's position
			bullet.transform.position = transform.position;
			//Access another script (rigidbody) and use its function
			//set ForceMode.Impulse because we apply it once and not over time
			bullet.GetComponent<Rigidbody> ().AddForce (transform.forward * shootForce, ForceMode.Impulse);
			shootTime = Time.time;
			// destroy it after 4 sec
			Destroy (bullet, 4.0f);
		}
	}

	private void ReverseDirection()	{
		direction = -direction;
		originalPosition = transform.position;
		destination = new Vector3 (originalPosition.x, originalPosition.y + (maxDistance * direction), originalPosition.z);
		startTime = Time.time;
	}

	private void ShootBullet()	{
		shootTime = Time.time;
	}
}
