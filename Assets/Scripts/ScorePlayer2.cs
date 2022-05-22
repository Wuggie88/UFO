using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer2 : MonoBehaviour
{
    public static float scorePlayer2;
	public float scoreP2;
	public float cowValue;
	public float redneckValue;
	public Text scoreTextP2;
	public DeathMenu deathMenu;
	public float scoreDecreaser;
	public EnemyPlane enemyPlane;
	public int pointsToGivePlayer2;
	public string textToShowCow;
	public string textToShowRedneck;
	public GameObject spawners;
    public SpawnPlanes planes;
    public MobsSpawn mobs;
    public GameObject sun;
    public SunMovement sunMovement;
    public GameObject mobSound;
    public AudioSource mobSFX;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreP2 = 0;
        SetCountTextP2();
        enemyPlane = GetComponent<EnemyPlane>();
        spawners = GameObject.Find("Main Camera");
        mobs = spawners.GetComponent<MobsSpawn>();
        planes = spawners.GetComponent<SpawnPlanes>();
        sun = GameObject.Find("Sun");
        sunMovement = sun.GetComponent<SunMovement>();
        mobSound = GameObject.Find("MobPickup");
        mobSFX = mobSound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scorePlayer2 = scoreP2;

        if (scoreP2 > scoreDecreaser)
        {
            scoreP2 -= Time.deltaTime * scoreDecreaser;
            scoreTextP2.text = ((int)scoreP2).ToString()  + " :Player 2";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
            scoreP2 += cowValue;
            SpawnTextCow();
            SetCountTextP2();
            mobSFX.Play();
        }
        else if (other.gameObject.CompareTag("PickUp2"))
        {
            Destroy(other.gameObject);
            scoreP2 += redneckValue;
            SpawnTextRedneck();
            SetCountTextP2();
            mobSFX.Play();
        }
    }

    void SetCountTextP2()
    {
        scoreTextP2.text = scoreP2.ToString() + " :Player 2";
    }

    public void SpawnTextCow()
    {
        GameObject PointsText = Instantiate(Resources.Load("Prefabs/TextOnSpot")) as GameObject;

        if (PointsText.GetComponent<TextOnSpotScript>() != null)
        {
            var givePointsText = PointsText.GetComponent<TextOnSpotScript>();
            givePointsText.DisplayPoints = pointsToGivePlayer2;
            givePointsText.DisplayText = textToShowCow;
        }
        PointsText.transform.position = gameObject.transform.position;
    }

    public void SpawnTextRedneck()
    {
        GameObject PointsText = Instantiate(Resources.Load("Prefabs/TextOnSpot")) as GameObject;

        if (PointsText.GetComponent<TextOnSpotScript>() != null)
        {
            var givePointsText = PointsText.GetComponent<TextOnSpotScript>();
            givePointsText.DisplayPoints = pointsToGivePlayer2;
            givePointsText.DisplayText = textToShowRedneck;
        }
        PointsText.transform.position = gameObject.transform.position;
    }

}
