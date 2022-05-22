using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public int playerCounter; // counter for pickups for player
    public bool enoughCollected = false; // Has collected enough pickups?
    public int timeActivated = 15; // the time the powerup is active
    public GameObject shield; // reference to gameobject shield
    public bool shieldActive = false; // Is the shield active
    public Slider Slider; //picks the slider for shieldbar
    public Image FillImage; //the fill image for Shieldbar
    public GameObject shieldSlider; //the shield slider gameobject to set it active and deactivate
    public AudioSource shieldSFX;
    public GameObject shieldHit;
    public AudioSource shieldHitSFX;
    public GameObject FirePoint2;
    public GameObject FirePoint3;
    public GameObject FirePoint4;
    public GameObject FirePoint5;
    public int PointsToGiveplayerShield;
    public string TextToShowShield;
	public int PointsToGiveplayerBullet;
	public string TextToShowBullet;
	public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        shieldSFX = shield.GetComponent<AudioSource>();
        shieldHit = GameObject.Find("ShieldHit");
        shieldHitSFX = shieldHit.GetComponent<AudioSource>();
		offset = new Vector3(-1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // calls the counter from the powerupCounter script on the gameObject hatch
        playerCounter = GameObject.Find("Player/Hatch").GetComponent<PowerupCounter>().playerCounter;

        if (playerCounter == 6 && enoughCollected == false)
        {
            StartCoroutine(ActivatePowerup());
            enoughCollected = true;
        }

        if (enoughCollected == true && playerCounter == 1)
            enoughCollected = false;

    }

    IEnumerator ActivatePowerup()
    {
        int dice = Random.Range(1, 6);

        if (dice >= 3)
        {
			// if dice is above 3 activate gun powerup
			FirePoint2.SetActive(true);
            FirePoint3.SetActive(true);
            FirePoint4.SetActive(true);
            FirePoint5.SetActive(true);
			SpawnTextMultipleBullets();
		}
        else if (dice < 3)
        {
            // activating shield
            SpawnTextShield();
            shield.SetActive(true);
            shieldActive = true;
            shieldSlider.SetActive(true);
            SetShieldUI();
            shieldSFX.Play();
        }
        yield return new WaitForSeconds(timeActivated);
        
        // Deactivating weapon powerup
        FirePoint2.SetActive(false);
        FirePoint3.SetActive(false);
        FirePoint4.SetActive(false);
        FirePoint5.SetActive(false);
        // Deactivating shield powerup
        shieldActive = false;
        shield.SetActive(false);
        shieldSlider.SetActive(false);
        SetShieldUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if the shield is active and it hits the colliders of an enemy projectile or the ground the shield will lose health
        if (shieldActive && (other.gameObject.CompareTag("RifleBullet") || other.gameObject.CompareTag("PlaneProjectile") || other.gameObject.CompareTag("ExplosiveBarrel")))
        {
            other.gameObject.SetActive(false);
            SetShieldUI();
            shieldHitSFX.Play();

        }
    }

    public void SpawnTextShield()
    {
        GameObject PointsText = Instantiate(Resources.Load("Prefabs/TextOnSpot")) as GameObject;

        if (PointsText.GetComponent<TextOnSpotScript>() != null)
        {
            var givePointsText = PointsText.GetComponent<TextOnSpotScript>();
            givePointsText.DisplayPoints = PointsToGiveplayerShield;
            givePointsText.DisplayText = TextToShowShield;
        }
        PointsText.transform.position = gameObject.transform.position + offset;
    }

    public void SpawnTextMultipleBullets()
    {
        GameObject PointsText = Instantiate(Resources.Load("Prefabs/TextOnSpot")) as GameObject;
        if (PointsText.GetComponent<TextOnSpotScript>() != null)
        {
            var givePointsText = PointsText.GetComponent<TextOnSpotScript>();
			givePointsText.DisplayPoints = PointsToGiveplayerBullet;
			givePointsText.DisplayText = TextToShowBullet;
        }
		PointsText.transform.position = gameObject.transform.position + offset;
    }

    private void SetShieldUI()
    {
        Slider.value = timeActivated;
    }

}
