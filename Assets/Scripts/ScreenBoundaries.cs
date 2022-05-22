using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectHeight;
    private float objectWidth;
    //private float buffer = -0.3f;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, (screenBounds.y * -1) + objectHeight, screenBounds.y - objectHeight);
        viewPos.x = Mathf.Clamp(viewPos.x, (screenBounds.x * -1) + objectWidth, screenBounds.x - objectWidth);
        transform.position = viewPos;
    }
}
