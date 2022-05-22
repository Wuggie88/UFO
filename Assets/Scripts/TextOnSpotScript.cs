using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnSpotScript : MonoBehaviour
{
    public string DisplayText;
    public int DisplayPoints;
    public Text TextPrefab;
    public float Speed;
    public float DestroyAfter;

    private float Timer;

    void Start()
    {
        Timer = DestroyAfter;
        TextPrefab = GetComponentInChildren<Text>();
    }


    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            Destroy(gameObject);
        }

        if (DisplayPoints > 0)
        {
            TextPrefab.text = "+" + DisplayPoints;
        }
        else if (DisplayText != null)
        {
            TextPrefab.text = "+" + DisplayText;
        }

        if (Speed > 0)
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime, Space.World);
        }
    }
}
