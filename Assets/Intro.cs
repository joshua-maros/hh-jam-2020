using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    private float struggle = 0;
    private float totalStruggle = 4;
    public Image struggleBar;

    // Start is called before the first frame update
    void Start()
    {
        GlobalData.instance.totalBlackout.active = true;
        struggleBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalData.instance.useWasPressed)
        struggle += 1.01f;
        struggleBar.fillAmount = struggle / totalStruggle;
        if (struggle >= totalStruggle)
        {
            GlobalData.instance.totalBlackout.active = false;
            gameObject.SetActive(false);
        }
    }
}
