using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PS4;

public class Level1Complete : MonoBehaviour
{
    public int playerId;
    private void Update()
    {
        if (PS4Input.PadIsConnected(playerId)) 
        {
            // Option Key...
            KeyCode code = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick1Button7", true);
            if (Input.GetKey(code)) 
            {
                SceneManager.LoadScene("Level1");
            }
                
        }
    }
    public void LevelMenu()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
