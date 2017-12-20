using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour {

    public GameObject bulletJira;

    public float visibility;
    public int isAlive;
    public float shootInterval;
    public float shootFirce;
    private float shootTime;

    // Use this for initialization
    void Start () {
        ShootBullet();
    }
	
	// Update is called once per frame
	void Update () {

        if (Time.time > shootTime + shootInterval)
        {
            //Create new bullet
            GameObject bullet = GameObject.Instantiate(bulletJira);
            //Move it to our cube's position
            bullet.transform.position = GameObject.Find("Head").transform.position;
            //Access another script (rigidbody) and use its function
            //set ForceMode.Impulse because we apply it once and not over time
            bullet.GetComponent<Rigidbody>().AddForce(GameObject.Find("Head").transform.forward* shootForce, ForceMode.Impulse);
            shootTime = Time.time;
            // destroy it after 4 sec
            Destroy(bullet, 4.0f);
        }
 
    }
    private void ShootBullet()
    {
        shootTime = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(transform.gameObject, 1.0f);
        }
    }

}
