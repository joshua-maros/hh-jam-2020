using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaleHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFinale()
    {
        GlobalData.instance.StartFinale();
    }

    public void ToggleBlack()
    {
        GlobalData.instance.totalBlackout.SetActive(!GlobalData.instance.totalBlackout.activeSelf);
    }

    public void BlackSequence()
    {
        StartCoroutine("BSI");
    }

    private IEnumerator BSI()
    {
        float[] delays = {
            5, 5,
            5, 15,
            5, 15,
            5, 20,
            5, 15,

            5, 5,
            5, 15,
            5, 15,
            5, 20,
            5, 15,

            5, 5,
            5, 15,
            5, 15,
            5, 20,
            5, 15,

            5, 10,
            5, 10,
            5, 5,
            5, 5,
            5, 5,
        };
        foreach (float delay in delays)
        {
            ToggleBlack();
            yield return new WaitForSeconds(delay / 100.0f * 1.5f);
        }
        GlobalData.instance.totalBlackout.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        GlobalData.instance.credits.SetActive(true);
    }
}
