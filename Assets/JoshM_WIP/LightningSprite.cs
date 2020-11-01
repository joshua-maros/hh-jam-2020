using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightningSprite : MonoBehaviour
{
    private new SpriteRenderer light = null;
    private Color regularColor;
    public Color colorDuringLightning = new Color();

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<SpriteRenderer>();
        regularColor = light.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalData.instance.lightningNow)
        {
            light.color = colorDuringLightning;
        }
        else
        {
            light.color = regularColor;
        }
    }
}
