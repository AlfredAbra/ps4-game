using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Complete : MonoBehaviour
{

    public void LevelMenu()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
