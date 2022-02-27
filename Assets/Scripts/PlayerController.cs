using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float turnSpeed = 30f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // Move player forwards based on input
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector2.up * Time.deltaTime * speed * forwardInput);
        // Rotate vehicle baesd on input
        //transform.Rotate(Vector2, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
