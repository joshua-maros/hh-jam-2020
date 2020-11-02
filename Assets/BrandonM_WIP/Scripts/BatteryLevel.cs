using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BatteryLevel : MonoBehaviour
{
    Image batteryBar;
    public float maxTime = 5f;
    float timeLeft;
    public GameObject dangerText;
    public FlickerableLight flashlight;

    // Start is called before the first frame update
    void Start()
    {
        dangerText.SetActive(false);
        batteryBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            if (flashlight.IsOn())
            {
                timeLeft -= Time.deltaTime;
                batteryBar.fillAmount = timeLeft / maxTime;
            }
        } 
        else
        {
            dangerText.SetActive(true);
            flashlight.maxIntensity = 0.0f;
        }
    }
}
