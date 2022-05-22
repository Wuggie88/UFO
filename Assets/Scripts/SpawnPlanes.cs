using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlanes : MonoBehaviour
{

    public GameObject planePrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    public Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        StartCoroutine(planeWave());
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(planePrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y / 4, screenBounds.y / 1.2f));
    }

    IEnumerator planeWave()
    {
        while(true) {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
