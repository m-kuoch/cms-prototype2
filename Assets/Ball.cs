using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float BOOST_MULTIPLIER;
    public float MAX_SPEED;
    private float curBoostMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        this.curBoostMultiplier = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 curVelocity = GetComponent<Rigidbody2D>().velocity;
        Vector2 newVelocity = curVelocity + curBoostMultiplier * curVelocity.normalized;

        // Prevent going over
        if (newVelocity.magnitude <= MAX_SPEED)
        {
            GetComponent<Rigidbody2D>().velocity = newVelocity;
        }

        // Percentile decrease of boost multiplier
        if (Mathf.Abs(curBoostMultiplier - 0) <= float.Epsilon)
        {
            this.curBoostMultiplier = 0;
        }
        else
        {
            this.curBoostMultiplier *= 0.8f;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit wall");
            this.curBoostMultiplier = BOOST_MULTIPLIER;
        }
    }
}
