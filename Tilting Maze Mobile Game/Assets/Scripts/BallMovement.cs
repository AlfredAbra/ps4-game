using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PS4;

public class BallMovement : MonoBehaviour
{
    Rigidbody rb;

    float ballSpeed = 15f;

    public GameObject ball;

    public AudioSource soundEffects;

    public AudioClip spikeImpactSound;

    public AudioClip ballExplosionSound;

    public float sensH = 10;
    public float sensV = 10;

    public int playerId;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        soundEffects = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PS4Input.PadIsConnected(playerId)) 
        {
            // Option Key...
            KeyCode code = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button7", true);
            if (Input.GetKey(code))
                PS4Input.PadResetOrientation(playerId);

            //Movement
            Vector4 v = PS4Input.PadGetLastOrientation(0);
            // The acceleration.y variable is used within the z-axis part of the Vector3 variable so it matches the phone's tilt correctly (so if the phone is tilted forward it moves on te z-axis in the game scene).
            Vector3 ballTilt = new Vector3(-v.z, 0f, v.x);

            // This adds the velocity to the ball game object and also uses the ballSpeed value as well to move at a certain speed.
            rb.velocity = ballTilt * ballSpeed;

            // This moves the ball back to original start position if the player falls off the narrow bridge sections.
            if (ball.transform.position.y < -0.31f)
            {
                soundEffects.PlayOneShot(ballExplosionSound, 0.75f);

                ball.transform.position = new Vector3(0.418107271f, 1, 0.0181865692f);
            }
        }

    }

    private void FixedUpdate()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ice")
        {
            Debug.Log("Collided With Ice");
            ballSpeed = 40f;
        }

        if (collision.gameObject.tag == "Spikes")
        {
            soundEffects.PlayOneShot(spikeImpactSound,0.75f);

            PS4Input.PadSetVibration(playerId, 255, 255);
            ball.transform.position = new Vector3(0.418107271f, 1f, 0.0181865692f);
        }

        if (collision.gameObject.tag == "Exit")
        {
            SceneManager.LoadScene("Level2");
        }

        if (collision.gameObject.tag == "Exit2")
        {
            SceneManager.LoadScene("Level3");
        }

        if (collision.gameObject.tag == "Exit3")
        {
            SceneManager.LoadScene("Level4");
        }

        if (collision.gameObject.tag == "Exit4")
        {
            SceneManager.LoadScene("Level5");
        }

        if(collision.gameObject.tag == "Exit5")
        {
            SceneManager.LoadScene("LevelCompletionScreen");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ice")
        {
            ballSpeed = 15f;
        }

    }
}
