using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : MonoBehaviour
{

    public float speed;

    // Update is called once per frame

    private void Start()
    {
        Destroy(gameObject, 20.0f);
    }

    void Update()
    {
        transform.Translate(-Vector3.right * Time.deltaTime * speed);
    }
}
