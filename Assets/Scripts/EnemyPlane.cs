using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPlane : MonoBehaviour
{

    private int health = 5;
    private Rigidbody2D rb;
    private Material matWhite;
    private Material matDefault;
    private Object explosionRef1;
    private Object explosionRef2;
    private Object explosionRef3;
    private Object explosionRef4;
    private float pointAdd;
    SpriteRenderer sr;
    private bool scoreGiven;

    public float speed = 10.0f;
    public ScreenShaker Shaker;
    public float duration = 1f;
    public Score playerScore;
    public ScorePlayer2 player2Score;
    public GameObject hatch;
    public GameObject hatchPlayer2;
    public int PointsToGiveplayer;
    public string TextToShow;
    public GameObject PlaneDeath;
    public AudioSource PlaneDeathSFX;

    // Start is called before the first frame update
    void Start()
    {
        Shaker = Camera.main.GetComponent<ScreenShaker>();
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        explosionRef1 = Resources.Load("FragmentParticles");
        explosionRef2 = Resources.Load("PlaneSmokeBig");
        explosionRef3 = Resources.Load("PlaneSmokeSmall");
        explosionRef4 = Resources.Load("SphereParticles");
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        hatch = GameObject.Find("Player/Hatch");
        hatchPlayer2 = GameObject.Find("Player2/HatchPlayer2");
        playerScore = hatch.GetComponent<Score>();
        player2Score = hatchPlayer2.GetComponent<ScorePlayer2>();
        PlaneDeath = GameObject.Find("PlaneDeath");
        PlaneDeathSFX = PlaneDeath.GetComponent<AudioSource>();
        pointAdd = 5;
        scoreGiven = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((Shaker != null) && other.CompareTag("Bullet"))
        {
            Shaker.Shake(duration);
            Destroy(other.gameObject);
            health--;
            sr.material = matWhite;
            if (health <= 0)
            {
                Shaker.Shake(duration);
                KillSelfP1();
            }
            else
            {
                Invoke("ResetMaterial", .1f);
            }
        }  

        if ((Shaker != null) && other.CompareTag("BulletPlayer2"))
        {
            Shaker.Shake(duration);
            Destroy(other.gameObject);
            health--;
            sr.material = matWhite;
            if (health <= 0)
            {
                Shaker.Shake(duration);
                KillSelfP2();
            }
            else
            {
                Invoke("ResetMaterial", .1f);
            }
        }
    }

    void ResetMaterial ()
    {
        sr.material = matDefault;
    }

    public void KillSelfP1()
    {
            ExplosionCouroutine();
        if (scoreGiven == false)
        {
            playerScore.score += pointAdd;
            scoreGiven = true;


            //drop of health
            int range = Random.Range(1, 11);
            if (range < 10)
            {
                Debug.Log("Nothing dropped");
            }
            //if (range == 10)
            if (range == 10)
            {
                //code for loading the healthpack 
                Instantiate(Resources.Load("HealthPack"), transform.position, Quaternion.identity);
            }
        }

            SpawnText();
            Destroy(gameObject);
            PlaneDeathSFX.Play();
    
    }


    public void KillSelfP2()
    {
            ExplosionCouroutine();
        if (scoreGiven == false)
        {
            player2Score.scoreP2 += pointAdd;
            scoreGiven = true;

            int range = Random.Range(1, 11);
            if (range < 10)
            {
                Debug.Log("Nothing dropped");
            }

            if (range == 10)
            {
                Instantiate(Resources.Load("HealthPack"), transform.position, Quaternion.identity);
            }
        }

        SpawnText();
        Destroy(gameObject);
        PlaneDeathSFX.Play();
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

        void ExplosionCouroutine()
    {
        GameObject explosion = (GameObject)Instantiate(explosionRef1);
        GameObject explosion2 = (GameObject)Instantiate(explosionRef2);
        GameObject explosion3 = (GameObject)Instantiate(explosionRef3);
        GameObject explosion4 = (GameObject)Instantiate(explosionRef4);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        explosion2.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        explosion3.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        explosion4.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

}
