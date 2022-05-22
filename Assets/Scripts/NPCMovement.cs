using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public LayerMask groundMask; // is pulled check 
    public float speed = 1; // speed and refSpeed needs the same value on the NPC
    public float refSpeed = 1;
    Rigidbody2D myBody;
    Transform myTrans;


    // Start is called before the first frame update
    void Start ()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        //makes a raycast
        Vector2 lineCastPos = myTrans.position;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down * .3f);

        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down * .3f, groundMask); //Checks if npc is on the ground

        //Always moves forward
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;

        
        // If sucked up by tractor beam, it stops moving.
        if (!isGrounded)
        {
            speed = 0;
            //inBounds = true;
        }
        else
        {
            speed = refSpeed;
        }
        
        
    }
}
