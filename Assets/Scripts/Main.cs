using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Main : MonoBehaviour
{
    public GameObject player;
    public GameObject ball;

    public ParticleSystem goalAParticles;
    public ParticleSystem goalBParticles;

    // public GameObject goalAText;

    public Text goalAText;
    public Text goalBText;
    // public GameObject goalAText;
    public int numGoalsA = 0;
    public int numGoalsB = 0;

    // Constants for camera shake
    public float SHAKE_DURATION;
    public float SHAKE_MAGNITUDE;
    public float DAMPING_SPEED;
    Vector3 initialPosition;

    // Variables for camera shake
    private float shakeDuration = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
        Goal.OnScore += ResetGame;
        Goal.OnCameraShake += CameraShake;
        Ball.OnCameraShake += CameraShake;
    }

    void onDisable()
    {
        Goal.OnScore -= ResetGame;
        Goal.OnCameraShake -= CameraShake;
        Ball.OnCameraShake -= CameraShake;
    }


    // Update is called once per frame
    void Update()
    {
        // Shake code adapted from https://medium.com/nice-things-ios-android-development/basic-2d-screen-shake-in-unity-9c27b56b516
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * SHAKE_MAGNITUDE;

            shakeDuration -= Time.deltaTime * DAMPING_SPEED;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    void CameraShake()
    {
        shakeDuration = SHAKE_DURATION;
    }

    void ResetGame(string goalName)
    {
        // Debug.Log("Yoyoyo the event callback worked! " + goalName);
        if (goalName.Equals("GoalA"))
        {
            // Debug.Log("Playing particle system");
            goalAParticles.Stop();
            goalAParticles.Play();
            numGoalsA++;
        }
        else if (goalName.Equals("GoalB"))
        {
            // Debug.Log("Playing particle system");
            goalBParticles.Stop();
            goalBParticles.Play();
            numGoalsB++;
        }

        // player.transform.position = new Vector2(10, 0);

        goalAText.text = numGoalsA.ToString();
        goalBText.text = numGoalsB.ToString();
        // Debug.Log(goalAText.GetComponent<TextAsset>());

        // Reset ball position and velocity
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.transform.position = new Vector2(0, 0);
        return;
    }
}
