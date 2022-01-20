using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    public void LevelMenu()
    {
        SceneManager.LoadScene("LevelCompletionScreen");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
