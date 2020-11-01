using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggler : MonoBehaviour
{
    private new FlickerableLight light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<FlickerableLight>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ToggleLight"))
        {
            light.forceOff = !light.forceOff;
        }
    }
}
