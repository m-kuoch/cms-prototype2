using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject player;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
        Goal.OnScore += ResetGame;
    }

    void onDisable()
    {
        Goal.OnScore -= ResetGame;
    }


    // Update is called once per frame
    void Update()
    {

    }

    void ResetGame(string goalName)
    {
        Debug.Log("Yoyoyo the event callback worked! " + goalName);
        player.transform.position = new Vector2(10, 0);

        // Reset ball position and velocity
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.transform.position = new Vector2(0, 0);
        return;
    }
}
