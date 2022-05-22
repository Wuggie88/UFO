using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TractorPullController : MonoBehaviour
{
	public int pullForce;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.attachedRigidbody != null)
		{
			if (other.gameObject.tag != "Player" && other.gameObject.tag != "Player2" && other.gameObject.name != "Hatch" && other.gameObject.name != "HatchPlayer2" && other.gameObject.name != "Shield")
			{
				other.attachedRigidbody.AddForce(transform.up * pullForce);
				//Debug.Log("An Object is in the beaming zone");
			}
		}
	}


	private void FixedUpdate()
	{

	}
}
