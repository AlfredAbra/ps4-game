using UnityEngine;
using UnityEngine.PS4;
using System;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour 
{
	public float speed;
	private int score;
	public Text textScore;
	public Text textYouWin;

	public float sensH = 10;
	public float sensV = 10;

    public int playerId;


	// Use this for initialization
	void Start () 
	{
		score = 0;
		DisplayScore ();
		textYouWin.text = "";
        PS4Input.PadResetOrientation(playerId);
    }
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        if (PS4Input.PadIsConnected(playerId))
        {
            // Option Key...
            KeyCode code = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button7", true);
            if (Input.GetKey(code))
                PS4Input.PadResetOrientation(playerId);

			//Movement
            Vector4 v = PS4Input.PadGetLastOrientation(0);
                
            float moveHor = Mathf.Clamp(v.z * sensH, -1, 1);
            float moveVer = Mathf.Clamp(v.x * sensV, -1, 1);
            GetComponent<Rigidbody>().AddForce(new Vector3 (-moveHor, 0, -moveVer) * speed * Time.deltaTime);
        }
    }
	
	void Update()
	{
		for (int i = 0; i < Input.touchCount; i++) 
			if (Input.GetTouch (i).phase == TouchPhase.Began)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch (i).position);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity, -1))
				if (hit.transform.gameObject.tag == "PickUp")
					hit.transform.gameObject.SetActive (false);
		}

        DisplayScore();
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);
			score += 10;
		}
		DisplayScore ();
	}

	void DisplayScore ()
	{
        textScore.text = "SCORE: " + score.ToString();

        if (score >= 120)
			textYouWin.text = "YOU WIN!!!";
        else
            textYouWin.text = "";
    }
}
