using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public SpawnPlanes planes;
    public MobsSpawn mobs;
    public GameObject spawners;
    public float PlaneRespawn;
    public int MobRespawn;

    public void Start()
    {
        spawners = GameObject.Find("Main Camera");
        mobs = spawners.GetComponent<MobsSpawn>();
        planes = spawners.GetComponent<SpawnPlanes>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Timer"))
        {
            planes.respawnTime = PlaneRespawn;
            mobs.spawnTime = MobRespawn;
        }
    }
}
