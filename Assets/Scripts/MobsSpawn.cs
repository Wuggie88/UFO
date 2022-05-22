using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsSpawn : MonoBehaviour
{
    public GameObject cow; 
    public GameObject redneck; 
    public Camera cam;
    public int spawnTime = 5;
    public bool hasSpawned = false;
    GameObject mob;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

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
        int range = Random.Range(1, 3);
        if (range == 1)
            mob = cow;
        if (range == 2)
            mob = redneck;

        // Choosing a spawn position and instantiates the mob
        Vector3 spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(1.02f, 0.1f, 1f));
        Instantiate(mob, spawnPos, Quaternion.identity);

        // wait the spawnTime and resets the conditions for spawn.
        yield return new WaitForSeconds(spawnTime);

        hasSpawned = false;
    }
}
