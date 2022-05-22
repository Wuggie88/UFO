using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageCalculator : MonoBehaviour
{
	private Rigidbody2D rb;
	public float kineticEnergy;
	public float collisionEnergy;
	public float collisionFactor = 0.0001f;
	public float collisionMinimumEnergyToDamage = 10;
    public float maxKineticEnergy = 2000;
    public float maxCollisionEnergy = 2000;
    private void FixedUpdate()
	{
		KineticEnergy();
	}

    public void Update()
    {
        
        if (maxKineticEnergy < kineticEnergy)
        {
            kineticEnergy = maxKineticEnergy;
        }

        if (collisionEnergy > maxCollisionEnergy)
        {
            collisionEnergy = maxCollisionEnergy;
        }
        
        
    }

    private void KineticEnergy()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		kineticEnergy = 0.5f * rb.mass * Mathf.Pow(rb.velocity.sqrMagnitude, 2);
		//Debug.Log(kineticEnergy);
	}


	private void OnCollisionEnter2D(Collision2D other)
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		if (other.gameObject.GetComponent<Rigidbody2D>() != null && other.gameObject.GetComponent<CollisionDamageCalculator>() != null)
		{
			collisionEnergy = kineticEnergy + other.gameObject.GetComponent<CollisionDamageCalculator>().kineticEnergy;
			if (gameObject.GetComponent<HealthScript>() != null)
			{
                // if shield is active, don't deal damage
                if (other.gameObject.tag == "Shield")
                {
                    collisionEnergy = 0f;
                }

                // Deal damage based on both objects kinetic energy.
                if (collisionEnergy > collisionMinimumEnergyToDamage)
				{
                    gameObject.GetComponent<HealthScript>().TakeDamage(collisionEnergy * collisionFactor);
				}
			}
		}
		else
		{
			//Deal damage based on kinetic energy to self.
			if (kineticEnergy > collisionMinimumEnergyToDamage)
			{
				gameObject.GetComponent<HealthScript>().TakeDamage(kineticEnergy * collisionFactor);
			}
		}
		// Do damage without adding the other objects kinetic energy. (since without a rigidbody, it has none anyway)
	}

}
