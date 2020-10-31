using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryUpdate : MonoBehaviour
{
    public float battery = 100.0f;
    private const float coef = 0.3f;

    // Update is called once per frame
    void Update()
    {
        battery -= coef * Time.deltaTime;
    }
}
