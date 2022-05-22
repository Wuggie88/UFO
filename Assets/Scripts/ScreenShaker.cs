using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{

    [Range(0f, 2f)]
    public float Intensity;

    Transform target;
    Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Transform>();
        initialPos = target.localPosition;
    }

    float pendingShakeDuration = 0f;

    public void Shake(float duration)
    {
        if(duration > 0)
        {
            pendingShakeDuration += duration;
        }
    }

    bool isShaking = false;

    // Update is called once per frame
    void Update()
    {
        if (pendingShakeDuration > 0 && !isShaking)
        {
            StartCoroutine(DoShake());
        }
    }

    IEnumerator DoShake()
    {
        isShaking = true;

        var startTime = Time.realtimeSinceStartup;
        while(Time.realtimeSinceStartup < startTime + pendingShakeDuration)
        {
            var randomPoint = new Vector3(Random.Range(-1f, 1f) * Intensity, Random.Range(-1f, 1f) * Intensity, initialPos.z);
            target.localPosition = randomPoint;
            yield return null;
        }

        pendingShakeDuration = 0f;
        target.localPosition = initialPos;
        isShaking = false;
    }
}
