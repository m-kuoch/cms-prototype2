using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 35f;
    private float turnSpeed = 200f;
    private float horizontalInput;
    private float verticalInput;
    private float spinInput;

    private Vector2 boostVector;

    // Start is called before the first frame update
    void Start()
    {
        boostVector = Vector2.zero;

        // Ignore collisions
        GameObject[] objs = GameObject.FindGameObjectsWithTag("IgnoredByPlayer");

        foreach (GameObject obj in objs)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Main.gameOver)
        {
            return;
        }

        horizontalInput = Input.GetAxis("Horizontal" + this.name);
        verticalInput = Input.GetAxis("Vertical" + this.name);
        spinInput = Input.GetAxis("Spin" + this.name);
        // Move player forwards based on input
        //transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
        //transform.Translate(Vector2.up * Time.deltaTime * speed * forwardInput);
        // Rotate vehicle baesd on input
        //transform.Rotate(Vector2, Time.deltaTime * turnSpeed * horizontalInput);

        // GetComponent<Rigidbody2D>().velocity = Vector2.right * Time.deltaTime * speed * horizontalInput;
        // GetComponent<Rigidbody2D>().velocity = Vector2.up * Time.deltaTime * speed * verticalInput;

        // GetComponent<Rigidbody2D>().velocity = new Vector2(Time.deltaTime * speed * horizontalInput,
        //     Time.deltaTime * speed * verticalInput);

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * horizontalInput, speed * verticalInput) + boostVector;
        if (Mathf.Abs(boostVector.magnitude - 0) <= 0.001)
        {
            boostVector = Vector2.zero;
        }
        else
        {
            boostVector = 0.8f * boostVector;
        }



        GetComponent<Rigidbody2D>().angularDrag = 0;
        GetComponent<Rigidbody2D>().angularVelocity = spinInput * turnSpeed;
        //GetComponent<Rigidbody2D>().MoveRotation(spinInput * turnSpeed);

        // Debug.Log(GetComponent<Rigidbody2D>().angularVelocity);

        //GetComponent<Rigidbody2D>().AddForce(Vector2.right * Time.deltaTime * speed * horizontalInput, ForceMode2D.Impulse);
        //GetComponent<Rigidbody2D>().AddForce(Vector2.up * Time.deltaTime * speed * verticalInput, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "GivesPlayerBoost")
        {
            Debug.Log("Increasing velocity by" + col.relativeVelocity);
            boostVector = 2 * col.relativeVelocity;
        }
    }
}
