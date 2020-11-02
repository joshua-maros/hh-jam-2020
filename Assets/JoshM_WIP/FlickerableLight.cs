using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlickerableLight : MonoBehaviour
{
    private new Light2D light = null;
    public float maxIntensity = 1.0f;
    private bool currentlyOn = true;

    private List<float> nextFlickers = new List<float>();
    private float flickerTimer = 0.0f;
    public float minFlickerTime = 0.05f, maxFlickerTime = 0.1f;
    public bool flickerAlways = false;
    public bool forceOff = false;

    public void DoFlickers(float totalTime)
    {
        while (totalTime > 0.0f)
        {
            float offTime = Random.Range(minFlickerTime, maxFlickerTime);
            float onTime = Random.Range(minFlickerTime, maxFlickerTime);
            totalTime -= offTime + onTime;
            nextFlickers.Add(offTime);
            nextFlickers.Add(onTime);
        }
    }

    public bool IsOn()
    {
        return !forceOff;
    }

    public void Toggle()
    {
        currentlyOn = !currentlyOn;
        if (currentlyOn)
        {
            light.intensity = maxIntensity;
        }
        else
        {
            light.intensity = 0.0f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
        maxIntensity = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (forceOff)
        {
            if (currentlyOn)
            {
                Toggle();
            }
        }
        else if (nextFlickers.Count > 0)
        {
            flickerTimer += Time.deltaTime;
            float nextTime = nextFlickers[0];
            if (flickerTimer >= nextTime)
            {
                flickerTimer -= nextTime;
                nextFlickers.RemoveAt(0);
                Toggle();
            }
        }
        else if (flickerAlways)
        {
            DoFlickers(10.0f);
        }
        else if (!forceOff && !currentlyOn)
        {
            Toggle();
        }
    }
}
