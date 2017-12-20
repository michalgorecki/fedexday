using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public float speed;
    public float jumpSpeed = 100.0f;
   // private bool onGround = false;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
           rb = GetComponent<Rigidbody>();
       }
    float movementSpeed;

    void FixedUpdate()
       {
        float amountToMove = movementSpeed * Time.deltaTime;
        float moveHorizontal = Input.GetAxis("Horizontal");
           float moveVertical = Input.GetAxis("Vertical");

           Vector3 movement = new Vector3(moveHorizontal,0.0f, 0.0f);
           Vector3 jump = (Input.GetAxis("Horizontal") * -Vector3.left * amountToMove) + (Input.GetAxis("Vertical") * Vector3.forward * amountToMove);

        rb.MovePosition(transform.position + movement * speed);

        if (Input.GetKeyDown("up"))
        {
            rb.AddForce(transform.position * jumpSpeed, ForceMode.Force);
        }

       }
    void OnCollisionStay(Collision collision)
    {
      // onGround = true;
    }
}
