using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Score score;
    public ScorePlayer2 scorePlayer2;
    public GameObject player;
    public GameObject player2;
    public SpawnPlanes planes;
    public MobsSpawn mobs;
    public GameObject spawners;
    public float PlaneRespawn;
    public int MobRespawn;
    public AudioSource playerAudio;
    public GameObject sun;
    public SunMovement sunMovement;

    private PlayerController playerController;
    private PlayerController playerController2;


    public void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        playerController2 = player2.GetComponent<PlayerController>();
        spawners = GameObject.Find("Main Camera");
        mobs = spawners.GetComponent<MobsSpawn>();
        planes = spawners.GetComponent<SpawnPlanes>();
        sun = GameObject.Find("Sun");
        sunMovement = sun.GetComponent<SunMovement>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Timer"))
        {
            score.OnDeath();

            playerController.speed = 0;
            playerController2.speed = 0;

            planes.respawnTime = PlaneRespawn;
            mobs.spawnTime = MobRespawn;
            player.SetActive(false);
            player2.SetActive(false);
            sunMovement.speed = 0;

            GameObject[] killAllPlanes;
            killAllPlanes = GameObject.FindGameObjectsWithTag("Plane");
            for (int i = 0; i < killAllPlanes.Length; i++)
            {
                Destroy(killAllPlanes[i].gameObject);
            }

            GameObject[] killAllRednecks;
            killAllRednecks = GameObject.FindGameObjectsWithTag("PickUp2");
            for (int i = 0; i < killAllRednecks.Length; i++)
            {
                Destroy(killAllRednecks[i].gameObject);
            }

            GameObject[] killAllCows;
            killAllCows = GameObject.FindGameObjectsWithTag("PickUp");
            for (int i = 0; i < killAllCows.Length; i++)
            {
                Destroy(killAllCows[i].gameObject);
            }

            GameObject[] killAllBarrels;
            killAllBarrels = GameObject.FindGameObjectsWithTag("ExplosiveBarrel");
            for (int i = 0; i < killAllBarrels.Length; i++)
            {
                Destroy(killAllBarrels[i].gameObject);
            }

        }
    }
}
