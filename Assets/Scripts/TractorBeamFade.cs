using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TractorBeamFade : MonoBehaviour
{

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Color c = sr.material.color;
        c.a = 0f;
        sr.material.color = c;
    }

    // Update is called once per frame
   IEnumerator FadeIn()
    {
        if (Input.GetKeyDown("space"))
        {
            for (float f = 0.05f; f <= 1; f += 0.05f)
            {
                Color c = sr.material.color;
                c.a = f;
                sr.material.color = c;
                yield return new WaitForSeconds(0.05f);
            }
        }
         
    }

    public void StartFadingIn()
    {
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeOut()
    {
        if(Input.GetKeyUp("space"))
        {
            for (float f = 1f; f >= -0.05f; f -= 0.05f)
            {
                Color c = sr.material.color;
                c.a = f;
                sr.material.color = c;
                yield return new WaitForSeconds(0.05f);
            }
        }
        
    }

    public void StartFadingOut()
    {
        StartCoroutine("FadeOut");     
    }
}
