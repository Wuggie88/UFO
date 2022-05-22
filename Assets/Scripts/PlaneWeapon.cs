using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneWeapon : MonoBehaviour
{

    public Transform planeFirePoint;
    public Transform planeBombPoint;
    public GameObject planeBulletPrefab;
    public GameObject planeBombPrefab;
    public Transform Plane;
    public AudioSource shooting;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchProjectile", Random.Range(1.0f, 2.0f), Random.Range(1.5f, 2.5f));
        InvokeRepeating("LaunchBomb", Random.Range(1.0f, 5.0f), Random.Range(3.0f, 6.0f));
    }

    // Update is called once per frame
    void LaunchProjectile()
    {
        StartCoroutine(PlaneShooting());
    }

    IEnumerator PlaneShooting()
    {
        Instantiate(planeBulletPrefab, planeFirePoint.position, planeFirePoint.rotation);
        shooting.Play();
        yield return new WaitForSeconds(0.08f);
        Instantiate(planeBulletPrefab, planeFirePoint.position, planeFirePoint.rotation);
        shooting.Play();
        yield return new WaitForSeconds(0.08f);
        Instantiate(planeBulletPrefab, planeFirePoint.position, planeFirePoint.rotation);
        shooting.Play();
    }

    void LaunchBomb()
    {
        Instantiate(planeBombPrefab, planeBombPoint.position, planeBombPoint.rotation);
    }
}
