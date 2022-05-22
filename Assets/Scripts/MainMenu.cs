using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Text highscoretext; 

    public void Start()
    {
        highscoretext.text = "Highscore: " + (int)PlayerPrefs.GetFloat("Highscore");
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
