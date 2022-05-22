using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float damage = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.right * speed;
    }

    // Update is called once per frame
    void Awake()
    {
        Destroy(this.gameObject, 2.0f);
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
    }
}
