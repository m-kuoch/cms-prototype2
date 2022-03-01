using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject player;
    public GameObject ball;

    public GameObject goalAText;
    // public GameObject goalAText;
    public int numGoalsA = 0;
    public int numGoalsB = 0;

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
        if (goalName.Equals("GoalA"))
        {
            numGoalsA++;
        }
        else if (goalName.Equals("GoalB"))
        {
            numGoalsB++;
        }

        player.transform.position = new Vector2(10, 0);

        // goalAText.text += numGoalsA;
        // goalAText.
        // Debug.Log(goalAText.GetComponent<TextAsset>());

        // Reset ball position and velocity
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.transform.position = new Vector2(0, 0);
        return;
    }
}
