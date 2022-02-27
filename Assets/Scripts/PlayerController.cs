using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 400f;
    private float turnSpeed = 30f;
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // Move player forwards based on input
        //transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
        //transform.Translate(Vector2.up * Time.deltaTime * speed * forwardInput);
        // Rotate vehicle baesd on input
        //transform.Rotate(Vector2, Time.deltaTime * turnSpeed * horizontalInput);

        // GetComponent<Rigidbody2D>().velocity = Vector2.right * Time.deltaTime * speed * horizontalInput;
        // GetComponent<Rigidbody2D>().velocity = Vector2.up * Time.deltaTime * speed * verticalInput;

        GetComponent<Rigidbody2D>().velocity = new Vector2(Time.deltaTime * speed * horizontalInput,
            Time.deltaTime * speed * verticalInput);
        
        //Debug.Log(horizontalInput);
        
        //GetComponent<Rigidbody2D>().AddForce(Vector2.right * Time.deltaTime * speed * horizontalInput, ForceMode2D.Impulse);
        //GetComponent<Rigidbody2D>().AddForce(Vector2.up * Time.deltaTime * speed * verticalInput, ForceMode2D.Impulse);
    }
}
