using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startgame : MonoBehaviour
{
    public GameObject Player;
    public GameObject Player2;
    public Transform PlayerSpawnPoint;
    public Transform Player2SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Player.SetActive(true);
        Player2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
