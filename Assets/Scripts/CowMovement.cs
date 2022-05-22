using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMovement : MonoBehaviour
{
    public LayerMask groundMask; // is on ground
    public float speed = 1; // speed and refSpeed needs the same value on the NPC
    public float refSpeed = 1;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;

    public GameObject Player;
    public AudioSource npcSound;
    public bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Checks if it is grounded and if it is within bounds with a raycast
        Vector2 lineCastPos = myTrans.position;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down * .25f);

        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down * .25f, groundMask); // isGrounded is true if the liecast hit the graound

        //Always move forward
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;


        // If sucked up by tractor beam, it stops moving. - Skal nok laves om til if cow is hit by tractorbeam collider then speed = 0;
        if (!isGrounded)
        {
            speed = 0;
            //inBounds = true;
        }
        else
        {
            speed = refSpeed;
        }

        // Compares the distance between the player and the npc
        float distance = Vector3.Distance(myTrans.position, Player.transform.position);

        // Makes so that the cow audio plays if near
        if (distance < 5)
        {
            if (hasPlayed == false)
            {
                hasPlayed = true;
                npcSound.Play();
            }
        }
        else
        {
            hasPlayed = false;
        }


    }
}
