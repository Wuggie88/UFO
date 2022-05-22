using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchController : MonoBehaviour
{
    public Collider2D hatchCollider;

    // Start is called before the first frame update
    void Start()
    {
        hatchCollider = GetComponent<Collider2D>();
        hatchCollider.enabled = !hatchCollider.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("Hatch"))
        {
            if (Input.GetKeyDown("v"))
            {
                hatchCollider.enabled = !hatchCollider.enabled;
            }

            if (Input.GetKeyUp("v"))
            {
                hatchCollider.enabled = !hatchCollider.enabled;
            }
        }
        
        if (CompareTag("HatchPlayer2"))
        {
            if (Input.GetKeyDown("l"))
            {
                hatchCollider.enabled = !hatchCollider.enabled;
            }

            if (Input.GetKeyUp("l"))
            {
                hatchCollider.enabled = !hatchCollider.enabled;
            }
        }
        
    }
}
