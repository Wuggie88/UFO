using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;
    public Camera cam;
    public int spawnTime;
    public bool hasSpawned = false;
    GameObject treeMob;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        //spawnTime = Random.Range(4, 10);      
    }

    // Update is called once per frame
    void Update()
    {
        // if it hasn't spawned, start corutine and turn hasSPawned to true
        if (hasSpawned == false)
        {
            StartCoroutine(mySpawn());
            hasSpawned = true;
        }

    }

    IEnumerator mySpawn()
    {
        // a randomiser for what spawns each time
        int range = Random.Range(1, 5);
        if (range == 1)
            treeMob = tree1;
        if (range == 2)
            treeMob = tree2;
        if (range == 3)
            treeMob = tree3;
        if (range == 4)
            treeMob = tree4;

        // Choosing a spawn position and instantiates the mob
        Vector3 spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(1.5f, 0.11f, 11.5f));
        Instantiate(treeMob, spawnPos, Quaternion.identity);

        // wait the spawnTime and resets the conditions for spawn.
        yield return new WaitForSeconds(spawnTime = Random.Range(2,6));

        hasSpawned = false;
    }
}
