using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBulletScript : MonoBehaviour
{
	public float speed = 10.0f;
	public float damage = 5f;
	//public float lifetime = 5.0f;
	

	// Start is called before the first frame update
	void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
		
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.GetComponent<HealthScript>() != null)
		{
			other.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
			if (other.gameObject.tag == "Shield")
			{
                //Don't destroy instance yet. (To allow for deflection)
                damage = 0f;
            }
			else
			{
				Destroy(gameObject, 0.0f);
			}
		}
		else
		{
			Destroy(gameObject, 0.5f);
		}
	}


	private void Awake()
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.TransformDirection(0.0f, speed, 0);
		Destroy(gameObject, 1.0f);
	}

	
}
