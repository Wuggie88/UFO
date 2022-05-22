using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDeath : MonoBehaviour
{
    private Object explosionRef9;
    private Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;

    public AudioSource SplatSFX;
    public bool isDead = false;
    public ScreenShaker Shaker;
    public float duration = 1f;
    public Score playerScore;
    public ScorePlayer2 player2Score;
    public GameObject hatch;
    public GameObject hatchPlayer2;
    public int PointsToGiveplayer;
    public string TextToShow;
    public GameObject deathAudio;

    // Start is called before the first frame update
    void Start()
    {
        explosionRef9 = Resources.Load("BloodParticles");
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        Shaker = Camera.main.GetComponent<ScreenShaker>();
        hatch = GameObject.Find("Player/Hatch");
        hatchPlayer2 = GameObject.Find("Player2/HatchPlayer2");
        playerScore = hatch.GetComponent<Score>();
        player2Score = hatchPlayer2.GetComponent<ScorePlayer2>();
        deathAudio = GameObject.Find("MobDeath");
        SplatSFX = deathAudio.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Shaker.Shake(duration);
            gameObject.GetComponent<HealthScript>().CurrentHealth -= 1;
            sr.material = matWhite;

            if (gameObject.GetComponent<HealthScript>().CurrentHealth <= 0)
            {
                if (!isDead)
                {
                    // Run ScreenShake
                    Shaker.Shake(duration);
                    // Play death animation + particles
                    DeathCoroutine();
                    // Play death sound
                    SplatSFX.Play();
                    // Hide sprite
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    // Remove gameObject once sound is done playing
                    Destroy(gameObject);
                    isDead = true;
                    // Add 3 points to Player 1 Score
                    playerScore.score += 3;
                    // Show the +Score floating text
                    SpawnText();
                }
            }
            else
            {
                Invoke("ResetMaterial", .1f);
            }
        }

        if (other.gameObject.CompareTag("Player2"))
        {
            Shaker.Shake(duration);
            gameObject.GetComponent<HealthScript>().CurrentHealth -= 1;
            sr.material = matWhite;

            if (gameObject.GetComponent<HealthScript>().CurrentHealth <= 0)
            {
                if (!isDead)
                {
                    // Run ScreenShake
                    Shaker.Shake(duration);
                    // Play death animation + particles
                    DeathCoroutine();
                    // Play death sound
                    SplatSFX.Play();
                    // Hide sprite
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    // Remove gameObject once sound is done playing
                    Destroy(gameObject);
                    isDead = true;
                    // Add 3 points to Player 1 Score
                    player2Score.scoreP2 += 3;
                    // Show the +Score floating text
                    SpawnText();
                }
            }
            else
            {
                Invoke("ResetMaterial", .1f);
            }
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            gameObject.GetComponent<HealthScript>().CurrentHealth -= 1;
            if (gameObject.GetComponent<HealthScript>().CurrentHealth <= 0)
            {
                if (!isDead)
                {
                    DeathCoroutine();
                    SplatSFX.Play();
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    Destroy(gameObject);
                    isDead = true;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Shaker.Shake(duration);
            gameObject.GetComponent<HealthScript>().CurrentHealth -= 7;
            Destroy(other.gameObject);
            sr.material = matWhite;

            if (gameObject.GetComponent<HealthScript>().CurrentHealth <= 0)
            {
                if(!isDead)
                {
                    // Run ScreenShake
                    Shaker.Shake(duration);
                    // Play death animation + particles
                    DeathCoroutine();
                    // Play death sound
                    SplatSFX.Play();
                    // Hide sprite
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    // Remove gameObject once sound is done playing
                    Destroy(gameObject);
                    isDead = true;
                    // Add 3 points to Player 1 Score
                    playerScore.score += 3;
                    // Show the +Score floating text
                    SpawnText();
                }
            }
            else
            {
                Invoke("ResetMaterial", .1f);
            }
        }

        if (other.gameObject.CompareTag("BulletPlayer2"))
        {
            Shaker.Shake(duration);
            gameObject.GetComponent<HealthScript>().CurrentHealth -= 7;
            Destroy(other.gameObject);
            sr.material = matWhite;

            if (gameObject.GetComponent<HealthScript>().CurrentHealth <= 0)
            {
                if(!isDead)
                {
                    // Run ScreenShake
                    Shaker.Shake(duration);
                    // Play death animation + particles
                    DeathCoroutine();
                    // Play death sound
                    SplatSFX.Play();
                    // Hide sprite
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    // Remove gameObject once sound is done playing
                    Destroy(gameObject);
                    isDead = true;
                    // Add 3 points to Player 1 Score
                    player2Score.scoreP2 += 3;
                    // Show the +Score floating text
                    SpawnText();
                }
            }
            else
            {
                Invoke("ResetMaterial", .1f);
            }
        }

    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }

    void DeathCoroutine()
    {
        GameObject explosion9 = (GameObject)Instantiate(explosionRef9);
        explosion9.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

}
