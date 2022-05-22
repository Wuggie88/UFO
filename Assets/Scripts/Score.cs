using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static float scoreP2;
    public float score;
    public float CowValue;
    public float RedneckValue;
    public Text scoreText;
    public DeathMenu deathMenu;
    public float scoreDecreaser;
    public EnemyPlane enemyplane;
    public int PointsToGiveplayer;
    public string TextToShowCow;
    public string TextToShowRedneck;
    public GameObject spawners;
    public SpawnPlanes planes;
    public MobsSpawn mobs;
    public GameObject sun;
    public SunMovement sunMovement;
    public GameObject MobSound;
    public AudioSource MobSFX;

    private bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        SetCountText();
        enemyplane = GetComponent<EnemyPlane>();
        spawners = GameObject.Find("Main Camera");
        mobs = spawners.GetComponent<MobsSpawn>();
        planes = spawners.GetComponent<SpawnPlanes>();
        sun = GameObject.Find("Sun");
        sunMovement = sun.GetComponent<SunMovement>();
        MobSound = GameObject.Find("MobPickup");
        MobSFX = MobSound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score > scoreDecreaser)
        {
            score -= Time.deltaTime * scoreDecreaser;
            scoreText.text = "Player 1: " + ((int)score).ToString();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
            score += CowValue;
            SpawnTextCow();
            SetCountText();
            MobSFX.Play();
        }
        else if (other.gameObject.CompareTag("PickUp2"))
        {
            Destroy(other.gameObject);
            score += RedneckValue;
            SpawnTextRedneck();
            SetCountText();
            MobSFX.Play();
        }
    }
    void SetCountText()
    {
        scoreText.text = "Player 1: " + score.ToString();
    }

    public void SpawnTextCow ()
    {
        GameObject PointsText = Instantiate(Resources.Load("Prefabs/TextOnSpot")) as GameObject;

        if (PointsText.GetComponent<TextOnSpotScript>() != null)
        {
            var givePointsText = PointsText.GetComponent<TextOnSpotScript>();
            givePointsText.DisplayPoints = PointsToGiveplayer;
            givePointsText.DisplayText = TextToShowCow;
        }
        PointsText.transform.position = gameObject.transform.position; 
    }

    public void SpawnTextRedneck()
    {
        GameObject PointsText = Instantiate(Resources.Load("Prefabs/TextOnSpot")) as GameObject;

        if (PointsText.GetComponent<TextOnSpotScript>() != null)
        {
            var givePointsText = PointsText.GetComponent<TextOnSpotScript>();
            givePointsText.DisplayPoints = PointsToGiveplayer;
            givePointsText.DisplayText = TextToShowRedneck;
        }
        PointsText.transform.position = gameObject.transform.position;
    }

    public void OnDeath()
    {
        scoreP2 = ScorePlayer2.scorePlayer2;
        isDead = true;
        if (PlayerPrefs.GetFloat("Highscore") < score)
            PlayerPrefs.SetFloat("Highscore", score);
        deathMenu.ToggleEndMenu(score, scoreP2);
        /*
        planes.respawnTime = 999999;
        mobs.spawnTime = 999999;
        sunMovement.speed = 0;
        
        GameObject[] killAllPlanes;
        killAllPlanes = GameObject.FindGameObjectsWithTag("Plane");
        for (int i = 0; i < killAllPlanes.Length; i++)
        {
            Destroy(killAllPlanes[i].gameObject);
        }

        GameObject[] killAllRednecks;
        killAllRednecks = GameObject.FindGameObjectsWithTag("PickUp2");
        for (int i = 0; i < killAllRednecks.Length; i++)
        {
            Destroy(killAllRednecks[i].gameObject);
        }

        GameObject[] killAllCows;
        killAllCows = GameObject.FindGameObjectsWithTag("PickUp");
        for (int i = 0; i < killAllCows.Length; i++)
        {
            Destroy(killAllCows[i].gameObject);
        }

        GameObject[] killAllBarrels;
        killAllBarrels = GameObject.FindGameObjectsWithTag("ExplosiveBarrel");
        for (int i = 0; i < killAllBarrels.Length; i++)
        {
            Destroy(killAllBarrels[i].gameObject);
        }
        */
    }
}
