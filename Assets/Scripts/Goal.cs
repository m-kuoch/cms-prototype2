using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject collidedObj = col.collider.gameObject;   
        Debug.Log("On: " + this.name + " | Collided: " + collidedObj.name);

        if (collidedObj.name.Equals("Ball")) {
            Debug.Log("Ball hit the goal, Score");
        }
    }
}
