using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupCounterPlayer2 : MonoBehaviour
{
    public int player2Counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player2Counter > 6)
            player2Counter = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if you pick up a pickup, counter increase with 1
        if (other.gameObject.CompareTag("PickUp") || other.gameObject.CompareTag("PickUp2"))
        {
            player2Counter++;
        }
    }
}
