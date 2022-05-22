using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPack : MonoBehaviour
{

    public GameObject player;
    public HealthScript health;
    public float heal = 10f;
    public string TextToShow;
    private int PointsToGiveplayer;
    public GameObject player2;
    public HealthScript health2;


    void Start()
    {
        player = GameObject.Find("Player");
        player2 = GameObject.Find("Player2");
        health = player.GetComponent<HealthScript>();
        health2 = player2.GetComponent<HealthScript>();
        //gameObject.SetActive(false);

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("you hit a healtpack");
        if (other.gameObject.CompareTag("Player"))
        {
            health.CurrentHealth += heal;
            Destroy(gameObject);
            SpawnText();
        }

        else if (other.gameObject.CompareTag("Player2"))
        {
            Debug.Log("player2 hit a healthpack");
            health2.CurrentHealth += heal;
            Destroy(gameObject);
            SpawnText();

        }
    }

    //floating text script
    public void SpawnText()
    {
        GameObject PointsText = Instantiate(Resources.Load("Prefabs/TextOnSpot")) as GameObject;

        if (PointsText.GetComponent<TextOnSpotScript>() != null)
        {
            var givePointsText = PointsText.GetComponent<TextOnSpotScript>();
            givePointsText.DisplayPoints = PointsToGiveplayer;
            givePointsText.DisplayText = TextToShow;
        }
        PointsText.transform.position = gameObject.transform.position;
    }

}
