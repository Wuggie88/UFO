using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public GameObject tractorBeamObject;
	public bool hatchOpen;
    public AudioSource FlightSFX;
    public float SoundModulator;
    public float SoundModulatorDividend = 20f;
    public KeyCode upP1;
    public KeyCode downP1;
    public KeyCode leftP1;
    public KeyCode rightP1;
    public KeyCode upP2;
    public KeyCode downP2;
    public KeyCode leftP2;
    public KeyCode rightP2;

    private Material matRed;
    private Material matDefault;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private TractorBeamFade fader;
    private GameObject gameObjects;



	void Start()
	{
        rb = this.GetComponent<Rigidbody2D>();
		tractorBeamObject.SetActive(false);
        sr = GetComponent<SpriteRenderer>();
        matRed = Resources.Load("RedFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        fader = GetComponent<TractorBeamFade>();
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

    void FixedUpdate()
	{
        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");*/
        if (CompareTag("Player"))
        { 
            if (Input.GetKey(upP1))
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }

            if (Input.GetKey(downP1))
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
            }

            if (Input.GetKey(leftP1))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }

            if (Input.GetKey(rightP1))
            {

                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }

        if (CompareTag("Player2"))
        {
            if (Input.GetKey(upP2))
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }

            if (Input.GetKey(downP2))
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
            }

            if (Input.GetKey(leftP2))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }

            if (Input.GetKey(rightP2))
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }

        //Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        //rb.AddForce(movement * speed);

        SoundModulator = ((Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y)) / SoundModulatorDividend) + 1f;
		//Debug.Log(SoundModulator);
		FlightSFX.pitch = SoundModulator;	
	}

	void Update()
	{
        if (gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown("v"))
            {
                // Tractor Beam ON
                //Debug.Log("Tractor beam is on")
                tractorBeamObject.SetActive(true);
                hatchOpen = true;
            }

            if (Input.GetKeyUp("v"))
            {
                // Tractor Beam OFF
                //Debug.Log("Tractor beam is off");
                tractorBeamObject.SetActive(false);
                hatchOpen = false;
            }
        }

        if (gameObject.CompareTag("Player2"))
        {
            if (Input.GetKeyDown("l"))
            {
                // Tractor Beam ON
                //Debug.Log("Tractor beam is on")
                tractorBeamObject.SetActive(true);
                hatchOpen = true;
            }

            if (Input.GetKeyUp("l"))
            {
                // Tractor Beam OFF
                //Debug.Log("Tractor beam is off");
                tractorBeamObject.SetActive(false);
                hatchOpen = false;
            }
        }
    }
}