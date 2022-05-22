using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public GameObject player1Prefab;
    public GameObject player2Prefab;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Instantiate(player1Prefab, GameObject.Find("PlayerSpawnPoint").transform.position, Quaternion.identity);
        }
    }
}
