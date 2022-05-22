using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTExplosion : MonoBehaviour
{
    public LayerMask PlayerMask;
    public ParticleSystem ExplosionParticles;
    public AudioSource ExplosionAudio;
    public float MaxDamage = 25f;
    public float duration = 1f;

    private RipplePostProcessor camRipple;
    private ScreenShaker shaker;
    private float DistanceToTarget;
	private bool isExploding = false;
	private float DamageDealt;
	//public float ExplosionForce = 1000f;
	//public float MaxLifeTime = 2f;
	//public float ExplosionRadius = 5f;
	//public float neededSpeed = 7;

	private void Start()
    {
        //Destroy(gameObject, MaxLifeTime);
        camRipple = Camera.main.GetComponent<RipplePostProcessor>();
        shaker = Camera.main.GetComponent<ScreenShaker>();
    }


    void Update()
    {
        
    }

	private void FixedUpdate()
	{
		if (gameObject.GetComponent<HealthScript>().CurrentHealth <= 0)
		{
			//Debug.Log("Barrel should explode now");
			gameObject.GetComponent<CircleCollider2D>().enabled = true;
			ExplosionParticles.transform.parent = null;
			ExplosionParticles.gameObject.SetActive(true);
			isExploding = true;

            camRipple.RippleEffect();
            shaker.Shake(duration);

			ExplosionParticles.Play();

			ExplosionAudio.Play();

			Destroy(ExplosionParticles.gameObject, ExplosionAudio.clip.length);
			Destroy(gameObject);
		}
	}
	
	private void OnCollisionStay2D(Collision2D other)
	{
		if (isExploding)
		{
			DistanceToTarget = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(other.transform.position.x - transform.position.x, 2f) + Mathf.Pow(other.transform.position.y - transform.position.y, 2f)));
			if (other.gameObject.GetComponent<HealthScript>() != null)
			{
				DamageDealt = MaxDamage / DistanceToTarget;
				//other.gameObject.GetComponent<HealthScript>().TakeDamage(DamageDealt);
				Debug.Log("Barrel dealt " + DamageDealt + " damage!");
			}
		}
	}

	/*
    private void OnTriggerEnter2D(Collider2D other)
    {
		if (!enabled) return;
		if (other.attachedRigidbody != null)
		{
			if (other.gameObject.GetComponent<Rigidbody2D>().velocity.sqrMagnitude > neededSpeed)
			{
				Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius, PlayerMask);

				for (int i = 0; i < colliders.Length; i++)
				{
					Rigidbody2D targetRigidbody = colliders[i].GetComponent<Rigidbody2D>();

					if (!targetRigidbody)
						continue;

					//float damage = CalculateDamage(targetRigidbody.position);

					//targetHealth.PlayerDamage(damage);
				}

				ExplosionParticles.transform.parent = null;
				ExplosionParticles.gameObject.SetActive(true);

				ExplosionParticles.Play();

				ExplosionAudio.Play();


				Destroy(ExplosionParticles.gameObject, ExplosionParticles.duration);
				Destroy(gameObject);
			}
		}
    }
	/*

    /*
        private float CalculateDamage(Vector2 targetPosition)
        {
            Vector2 explosionToTarget = targetPosition - transform.position;
            float explosionDistance = explosionToTarget.magnitude;

            float relativeDistance = (ExplosionRadius - explosionDistance)

            float damage = relativeDistance * MaxDamage;

            damage = Mathf.Max(0f, damage);
        }
    */

}