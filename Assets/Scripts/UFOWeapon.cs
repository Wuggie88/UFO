using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOWeapon : MonoBehaviour
{
    public Transform firePoint1, firePoint2, firePoint3, firePoint4, firePoint5;
    public GameObject bulletPrefab;
    public GameObject bulletPrefabP2;
    public Transform player;
    public AudioSource shootAudio;

    public GameObject FirePoint2;
    public GameObject FirePoint3;
    public GameObject FirePoint4;
    public GameObject FirePoint5;
    
    // Update is called once per frame
    void Update()
    {
        if(CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                shootP1();
                shootAudio.Play();
            }
        }

        if(CompareTag("Player2"))
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                shootP2();
                shootAudio.Play();
            }
        }
    }

    void shootP1()
    {
        Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);

        if (FirePoint2.activeInHierarchy)
            Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);

        if (FirePoint3.activeInHierarchy)
            Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);

        if (FirePoint4.activeInHierarchy)
            Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);

        if (FirePoint5.activeInHierarchy)
            Instantiate(bulletPrefab, firePoint5.position, firePoint5.rotation);
    }

    void shootP2()
    {
        Instantiate(bulletPrefabP2, firePoint1.position, firePoint1.rotation);

        if (FirePoint2.activeInHierarchy)
            Instantiate(bulletPrefabP2, firePoint2.position, firePoint2.rotation);

        if (FirePoint3.activeInHierarchy)
            Instantiate(bulletPrefabP2, firePoint3.position, firePoint3.rotation);

        if (FirePoint4.activeInHierarchy)
            Instantiate(bulletPrefabP2, firePoint4.position, firePoint4.rotation);

        if (FirePoint5.activeInHierarchy)
            Instantiate(bulletPrefabP2, firePoint5.position, firePoint5.rotation);
    }
}
