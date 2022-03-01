using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
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
        return;
    }
}
