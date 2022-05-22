using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public Text scoreText;
    public Text scoreP2Text;
    public Text winnerText;
    public Image Backgroundimage;

    string player1 = "Player 1";
    string player2 = "Player 2";
    string winner;

    private bool isShown = false;
    private float transition = 0.0f; 

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShown)
            return;

        transition += Time.deltaTime;
        Backgroundimage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.white, transition);
    }
    
    public void ToggleEndMenu (float score, float scoreP2)
    {
        if (score < scoreP2)
            winner = player2;
        else if (scoreP2 < score)
            winner = player1;

        gameObject.SetActive(true);
        scoreText.text = "score player 1: " + ((int)score).ToString();
        scoreP2Text.text = "score player 2: " + ((int)scoreP2).ToString();
        winnerText.text = "winner: " + winner;
        isShown = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
