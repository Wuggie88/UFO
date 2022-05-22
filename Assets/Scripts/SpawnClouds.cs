using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    public GameObject Cloud1;
    public GameObject Cloud2;
    public float respawnTime;
    private Vector2 screenBounds;
    public Camera MainCamera;
    GameObject mob;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        StartCoroutine(cloudWave());
    }

    private void spawnCloud()
    {
        var a = Random.Range(1, 3);
        if (a == 1)
            mob = Cloud1;
        if (a == 2)
            mob = Cloud2;
        mob.transform.position = new Vector2(screenBounds.x * 1.5f, Random.Range(-screenBounds.y / 20, screenBounds.y / 1.2f));
        Instantiate(mob);
    }

    IEnumerator cloudWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime = Random.Range(8,12));
            spawnCloud();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
