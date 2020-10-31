using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightningResponder : MonoBehaviour
{
    private new Light2D light = null;
    private float regularIntensity = 1.0f;
    private Color regularColor;
    public float intensityDuringLightning = 0.2f;
    public Color colorDuringLightning = new Color();

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
        regularIntensity = light.intensity;
        regularColor = light.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalData.instance.lightningNow)
        {
            light.intensity = intensityDuringLightning;
            light.color = colorDuringLightning;
        }
        else if (GlobalData.instance.blackoutNow)
        {
            light.intensity = 0.0f;
        }
        else
        {
            light.intensity = regularIntensity;
            light.color = regularColor;
        }
    }
}
