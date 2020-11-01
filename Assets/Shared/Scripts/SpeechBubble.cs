using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeechBubble : MonoBehaviour
{
    public GameObject spike = null;
    public GameObject target = null;
    public TextMeshProUGUI text = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowText(string text)
    {
        this.text.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        Vector3 offset = Vector3.up * 1.5f;
        Vector3 bubbleOffset = Vector3.up * 1.0f;
        Vector3 targetpos = target.transform.position + offset;
        Vector3 newPos = Vector3.Lerp(transform.position, targetpos + bubbleOffset, Time.deltaTime * 4.0f);
        transform.position = newPos;
        spike.transform.position = targetpos;
        float angle = Mathf.Atan2((targetpos.y - transform.position.y), (targetpos.x - transform.position.x)) * Mathf.Rad2Deg;
        spike.transform.eulerAngles = new Vector3(0.0f, 0.0f, angle + 90.0f);
        float scale = (transform.position - spike.transform.position).magnitude;
        spike.transform.localScale = new Vector3(scale, scale, scale);
    }
}
