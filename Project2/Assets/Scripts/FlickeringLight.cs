using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light flickeringLight;

    public float flickeringSpeed = 0.5f;
    public float minIntensity = 0.25f;
    public float maxIntensity = 1.0f;

    private float randomIntensity;

    // Start is called before the first frame update
    void Start()
    {
        if (flickeringLight == null)
        {
            flickeringLight = GetComponent<Light>();
        }
        randomIntensity = Random.Range(minIntensity, maxIntensity);
    }

    // Update is called once per frame
    void Update()
    {
        flickeringLight.intensity = Mathf.MoveTowards(
            flickeringLight.intensity, randomIntensity, Time.deltaTime * flickeringSpeed);

        if (Mathf.Abs(flickeringLight.intensity - randomIntensity) < 0.05)
        {
            randomIntensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}