using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private bool isDead = false;
    private Material matRed;
    private Material matDefault;
    private Object explosionRef1;
    private Object explosionRef2;
    private Object explosionRef3;
    private Object explosionRef4;
    private Object explosionRef5;
    private Object explosionRef6;
    private Object explosionRef7;
    private Object explosionRef8;

    public GameObject Player;
    public GameObject Player2;

    bool player1Active = true;
    bool player2Active = true;

    public DeathMenu deathMenu;
	public bool devMode = true;
    public Score score;
    public float startingHealth = 100f;
    public float CurrentHealth;
    public float maxHealth = 100f;
    private SpriteRenderer sr;
    public Slider Slider;
    public Image FillImage;
    public Color FullHealthColor = Color.green;
    public Color ZeroHealthColor = Color.red;
    public GameObject playerDeath;
    public AudioSource playerDeathSFX;
    public Transform PlayerSpawnPoint;
    public Transform Player2SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
		CurrentHealth = startingHealth;
        sr = GetComponent<SpriteRenderer>();
        matRed = Resources.Load("RedFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        explosionRef1 = Resources.Load("SphereParticles");
        explosionRef2 = Resources.Load("Explosion");
        explosionRef3 = Resources.Load("PlaneSmokeBig");
        explosionRef4 = Resources.Load("PlaneSmokeSmall");
        explosionRef5 = Resources.Load("BodyParticle");
        explosionRef6 = Resources.Load("HeadParticle");
        explosionRef7 = Resources.Load("GunParticle");
        explosionRef8 = Resources.Load("UfoParticle");
        playerDeath = GameObject.Find("playerDeath");
        playerDeathSFX = playerDeath.GetComponent<AudioSource>();

        SetHealthUI();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject)
        {
            sr.material = matRed;
            Invoke("ResetMaterial", .1f);
        }
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth > maxHealth)
            CurrentHealth = maxHealth;
        SetHealthUI();

        if (CurrentHealth < 0)
            CurrentHealth = 0;
    }

	public void TakeDamage(float amount)
	{
		CurrentHealth -= amount;

		SetHealthUI();

		if (CurrentHealth <= 0 && !isDead)
		{		
			isDead = true;

			if (gameObject.tag == "Player")
			{
                //Application.LoadLevel(Application.loadedLevel);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
                //SceneManager.LoadScene("Menu");
                //score.OnDeath();
                playerDeathSFX.Play();
                gameObject.SetActive(false);


                GameObject explosion1 = (GameObject)Instantiate(explosionRef1);
                explosion1.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                GameObject explosion2 = (GameObject)Instantiate(explosionRef2);
                explosion2.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                GameObject explosion3 = (GameObject)Instantiate(explosionRef3);
                explosion3.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                GameObject explosion4 = (GameObject)Instantiate(explosionRef4);
                explosion4.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                GameObject explosion5 = (GameObject)Instantiate(explosionRef5);
                explosion5.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                GameObject explosion6 = (GameObject)Instantiate(explosionRef6);
                explosion6.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                GameObject explosion7 = (GameObject)Instantiate(explosionRef7);
                explosion7.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                GameObject explosion8 = (GameObject)Instantiate(explosionRef8);
                explosion8.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                player1Active = false;
                Invoke("RespawnPlayer1", 3);
                Player.transform.position = PlayerSpawnPoint.position;

            }
            else if (gameObject.tag == "Player2")
            {
                //Application.LoadLevel(Application.loadedLevel);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
                //SceneManager.LoadScene("Menu");
                //score.OnDeath();
                playerDeathSFX.Play();
                gameObject.SetActive(false);


                GameObject explosion1 = (GameObject)Instantiate(explosionRef1);
                explosion1.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                GameObject explosion2 = (GameObject)Instantiate(explosionRef2);
                explosion2.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                GameObject explosion3 = (GameObject)Instantiate(explosionRef3);
                explosion3.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                GameObject explosion4 = (GameObject)Instantiate(explosionRef4);
                explosion4.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                GameObject explosion5 = (GameObject)Instantiate(explosionRef5);
                explosion5.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                GameObject explosion6 = (GameObject)Instantiate(explosionRef6);
                explosion6.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                GameObject explosion7 = (GameObject)Instantiate(explosionRef7);
                explosion7.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                GameObject explosion8 = (GameObject)Instantiate(explosionRef8);
                explosion8.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                player2Active = false;
                Invoke("RespawnPlayer2", 3);
                Player2.transform.position = Player2SpawnPoint.position;
            }
            else
			{
				GameObject.Destroy(gameObject);
			}
			
		}

	}

    public void RespawnPlayer1()
    {
        CurrentHealth = startingHealth;

        Player.SetActive(true);
        player1Active = true;
        isDead = false;
    }

    public void RespawnPlayer2()
    {
        CurrentHealth = startingHealth;

        Player2.SetActive(true);
        player2Active = true;
        isDead = false;
    }

    private void SetHealthUI()
    {
        Slider.value = CurrentHealth;

        FillImage.color = Color.Lerp(ZeroHealthColor, FullHealthColor, CurrentHealth / startingHealth);
    }

}
