using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScreenEnemy : MonoBehaviour
{
    public GameObject bulletJira;
    public GameObject bScreen;

    public int isAlive = 3;
    public float shootInterval;
    public float shootForce;
    private float shootTime;

    // Use this for initialization
    void Start()
    {
        ShootBulletBlueScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > shootTime + shootInterval)
        {
            //Create new bullet
            GameObject bullet = GameObject.Instantiate(bulletJira);
            //Move it to our cube's position
            bullet.transform.position = transform.position;
            //Access another script (rigidbody) and use its function
            //set ForceMode.Impulse because we apply it once and not over time
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.Impulse);
            shootTime = Time.time;
            // destroy it after 4 sec
            Destroy(bullet, 5.0f);
        }

    }
    private void ShootBulletBlueScreen()
    {
        shootTime = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            isAlive--;
            if (isAlive == 0)
            {
                Destroy(transform.gameObject, 1.0f);
            }
        }
    }

}