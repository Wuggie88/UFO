using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
	public bool isShooting = false;
	public float cooldown = 0.2f;
	public float range = 11f;
	public float damage = 1f;

    Vector2 distanceToPlayer;
    Vector2 distanceToPlayer2;
    float playerDistance;
    float player2Distance;

    public GameObject hostileTarget;
	public GameObject projectile;
	public GameObject muzzleEmitter;
    public GameObject player;
    public GameObject player2;

	bool isFlipped = false;

    public AudioSource gunshotAudio;

	public float despawnTime = 7;

	public bool isDisabled = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player2 = GameObject.Find("Player2");

        StartCoroutine(ShootingCoroutine());
    }



	// Update is called once per frame
	void Update()
    {
        if (player.activeInHierarchy == false)
            hostileTarget = player2;
        else if (player2.activeInHierarchy == false)
            hostileTarget = player;

        // Calculating distance between redneck and the players and chooses the closest
        distanceToPlayer = (player.transform.position - transform.position);
        distanceToPlayer2 = (player2.transform.position - transform.position);

        playerDistance = Mathf.Sqrt((distanceToPlayer.x * distanceToPlayer.x) + (distanceToPlayer.y * distanceToPlayer.y));
        player2Distance = Mathf.Sqrt((distanceToPlayer2.x * distanceToPlayer2.x) + (distanceToPlayer2.y * distanceToPlayer2.y));

        if (playerDistance < player2Distance)
            hostileTarget = player;
        else
            hostileTarget = player2;



        if (!isDisabled)
		{

			//-------------------- Aiming ----------------------
			float deltaX = hostileTarget.transform.position.x - transform.position.x;
            //Debug.Log("deltaX = " + deltaX.ToString());

            float distanceToTarget = Vector2.Distance(hostileTarget.transform.position, transform.position);
            //Debug.Log("distanceToTarget = " + distanceToTarget.ToString());




            if (distanceToTarget <= range)
			{
				transform.rotation = Quaternion.LookRotation(Vector3.forward, hostileTarget.transform.position - transform.position);
				isShooting = true;
				if (deltaX > 0 && isFlipped)
				{

					transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
					isFlipped = false;

				}
				else if (deltaX < 0 && !isFlipped)
				{
					transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
					isFlipped = true;
				}
			}
			else
			{
				isShooting = false;
			}

			if (transform.parent.GetComponent<NPCDeath>().isDead)
			{
				Debug.Log("Machine guns owner now dead");
				transform.parent = null;
				Destroy(gameObject, despawnTime);
				gameObject.GetComponent<Rigidbody2D>().simulated = true;
				gameObject.GetComponent<BoxCollider2D>().enabled = true;
				isDisabled = true;
				isShooting = false;
			}
		}
	}



	IEnumerator ShootingCoroutine()
	{
		while (true)
		{
			if (isShooting)
			{
				GameObject bullet = Instantiate(projectile, muzzleEmitter.transform.position, Quaternion.LookRotation(Vector3.forward, hostileTarget.transform.position - muzzleEmitter.transform.position)) as GameObject;
				bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * 300);

                gunshotAudio.Play();
				

				//Wait
				yield return new WaitForSeconds(cooldown);
			}
			else
			{
				//Just wait for next frame
				yield return null;
			}
		}
	}
}
