using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;

    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;

    public int frameCount = 1;

    private Vector3 originalPosition;
    private Vector3 destination;
    private int direction = 1;// 1 - up, -1 = down
    private float startTime;
    public float maxDistance;
    public float travelTime;

    private int isAlive = 2;

    // Use this for initialization
    void Start()
    {
        ReverseDirection();
    }
    
    // Update is called once per frame
    void Update()
    {
        //1. Fly up and down
        if (Time.time > startTime + travelTime)
        {
            //reverse travel direction
            ReverseDirection();
        }

        float currentTime = (Time.time - startTime) / travelTime;
        transform.position = Vector3.Lerp(originalPosition, destination, currentTime);

        if (Time.frameCount == frameCount)
        {
            frameCount += 40;
            //The Bullet instantiation happens here.
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            Temporary_RigidBody.AddForce(transform.right * Bullet_Forward_Force);

            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            Destroy(Temporary_Bullet_Handler, 10.0f);
        }
    }

    private void ReverseDirection()
    {
        direction = -direction;
        originalPosition = transform.position;
        destination = new Vector3(originalPosition.x, originalPosition.y + (maxDistance * direction), originalPosition.z);
        startTime = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.gameObject.tag == "PlayerBullet") {
            isAlive--;
            if (isAlive == 0)
            {
                Destroy(gameObject, 0.3f);
            }

        }
    }
}
