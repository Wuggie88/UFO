using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPickUp : MonoBehaviour
{
    private UnityEngine.Object explosionRef9;
    private UnityEngine.Object explosionRef1;
    private UnityEngine.Object explosionRef2;
    private UnityEngine.Object explosionRef3;
    private UnityEngine.Object explosionRef4;

    public int counter;
    public int counter2;
    public ScreenShaker shaker;
    public float duration = 1f;
    public Score playerScore;
    public ScorePlayer2 player2Score;
    public GameObject hatch;
    public GameObject hatchPlayer2;
    public int PointsToGiveplayer;
    public string TextToShow;
    public GameObject starPickup;
    public AudioSource StarPickupSFX;
    public GameObject FiveStarsSound;
    public AudioSource FiveStarsSFX;

    // Start is called before the first frame update
    void Start()
    {
        explosionRef9 = Resources.Load("BloodParticles");
        explosionRef1 = Resources.Load("FragmentParticles");
        explosionRef2 = Resources.Load("PlaneSmokeBig");
        explosionRef3 = Resources.Load("PlaneSmokeSmall");
        explosionRef4 = Resources.Load("SphereParticles");
        shaker = Camera.main.GetComponent<ScreenShaker>();
        hatch = GameObject.Find("Player/Hatch");
        hatchPlayer2 = GameObject.Find("Player2/HatchPlayer2");
        playerScore = hatch.GetComponent<Score>();
        player2Score = hatchPlayer2.GetComponent<ScorePlayer2>();
        counter = 0;
        counter2 = 0;
        starPickup = GameObject.Find("StarPickup");
        StarPickupSFX = starPickup.GetComponent<AudioSource>();
        FiveStarsSound = GameObject.Find("FiveStars");
        FiveStarsSFX = FiveStarsSound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            StarPickupSFX.Play();
            if (CompareTag("Player"))
                counter++;
            if (CompareTag("Player2"))
                counter2++;

            if (counter == 5 || counter2 == 5)
            {
                shaker.Shake(duration);
                Destroy(other.gameObject);
                FiveStarsSFX.Play();


                GameObject[] killAllPlanes;
                killAllPlanes = GameObject.FindGameObjectsWithTag("Plane");
                for (int i = 0; i < killAllPlanes.Length; i++)
                {
                    Destroy(killAllPlanes[i].gameObject);
                    GameObject explosion = (GameObject)Instantiate(explosionRef1);
                    GameObject explosion2 = (GameObject)Instantiate(explosionRef2);
                    GameObject explosion3 = (GameObject)Instantiate(explosionRef3);
                    GameObject explosion4 = (GameObject)Instantiate(explosionRef4);
                    explosion.transform.position = new Vector3(killAllPlanes[i].transform.position.x, killAllPlanes[i].transform.position.y, killAllPlanes[i].transform.position.z);
                    explosion2.transform.position = new Vector3(killAllPlanes[i].transform.position.x, killAllPlanes[i].transform.position.y, killAllPlanes[i].transform.position.z);
                    explosion3.transform.position = new Vector3(killAllPlanes[i].transform.position.x, killAllPlanes[i].transform.position.y, killAllPlanes[i].transform.position.z);
                    explosion4.transform.position = new Vector3(killAllPlanes[i].transform.position.x, killAllPlanes[i].transform.position.y, killAllPlanes[i].transform.position.z);

                }

                GameObject[] killAllRednecks;
                killAllRednecks = GameObject.FindGameObjectsWithTag("PickUp2");
                for (int i = 0; i < killAllRednecks.Length; i++)
                {
                    Destroy(killAllRednecks[i].gameObject);
                    GameObject explosion9 = (GameObject)Instantiate(explosionRef9);
                    explosion9.transform.position = new Vector3(killAllRednecks[i].transform.position.x, killAllRednecks[i].transform.position.y, killAllRednecks[i].transform.position.z);
                }

                GameObject[] killAllCows;
                killAllCows = GameObject.FindGameObjectsWithTag("PickUp");
                for (int i = 0; i < killAllCows.Length; i++)
                {
                    Destroy(killAllCows[i].gameObject);
                    GameObject explosion9 = (GameObject)Instantiate(explosionRef9); //new Vector3(transform.position.x, transform.position.y, transform.position.z)
                    explosion9.transform.position = new Vector3(killAllCows[i].transform.position.x, killAllCows[i].transform.position.y, killAllCows[i].transform.position.z);
                }

                GameObject[] killAllBarrels;
                killAllBarrels = GameObject.FindGameObjectsWithTag("ExplosiveBarrel");
                for (int i = 0; i < killAllBarrels.Length; i++)
                {
                    Destroy(killAllBarrels[i].gameObject);
                }

                if (counter == 5)
                {
                    playerScore.score += 50;
                    SpawnText();
                    counter -= 5;
                }

                if (counter2 == 5)
                {
                    player2Score.scoreP2 += 50;
                    SpawnText();
                    counter2 -= 5;
                }
                
            }

        }

    }

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
