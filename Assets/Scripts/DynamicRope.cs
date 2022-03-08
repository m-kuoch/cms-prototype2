using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicRope : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject[] prefabRopeSegs;
    public int numLinks = 25;
    void Start()
    {
        GenerateRope();
    }

    void GenerateRope()
    {
        Rigidbody2D prevBod = hook;
        for (int i = 0; i < numLinks; i++)
        {
            // int index = Random.Range(0, prefabRopeSegs.Length);

            GameObject newSeg = Instantiate((prefabRopeSegs[i]));
            newSeg.transform.parent = transform;
            newSeg.transform.position = transform.position;
            if (i == 0)
            {
                FixedJoint2D fj = newSeg.GetComponent<FixedJoint2D>();
                fj.connectedBody = prevBod;
            }
            else
            {
                HingeJoint2D hj = newSeg.GetComponent<HingeJoint2D>();
                hj.connectedBody = prevBod;
            }


            prevBod = newSeg.GetComponent<Rigidbody2D>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
