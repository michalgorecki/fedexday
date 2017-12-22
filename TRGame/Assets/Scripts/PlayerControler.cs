using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public float speed = 0.2f;
    public float jumpSpeed = 10.0f;
    private bool onGround = false;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
           rb = GetComponent<Rigidbody>();
       }

    void FixedUpdate()
       {
        float moveHorizontal = Input.GetAxis("Horizontal");

           Vector3 movement = new Vector3(moveHorizontal,0.0f, 0.0f);

        rb.MovePosition(transform.position + movement * speed);

        if (Input.GetKeyDown("up") && onGround == true)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            onGround = false;
        }
        
        if (Input.GetKeyUp("up"))
        {
            rb.AddForce(0.5f * Vector3.up * -jumpSpeed, ForceMode.Impulse);
        }

        if (transform.position.y < -10.0f)
        {
            rb.MovePosition(new Vector3(-10.0f, 1.0f, 0.0f));
        }

       }
    void OnCollisionStay(Collision collision)
    {
       onGround = true;
    }
}
