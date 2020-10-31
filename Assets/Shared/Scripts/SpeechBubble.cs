using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    public GameObject spike = null;
    public GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bubbleOffset = Vector3.up * 2.0f;
        Vector3 newPos = Vector3.Lerp(transform.position, target.transform.position + bubbleOffset, Time.deltaTime * 4.0f);
        transform.position = newPos;
        spike.transform.position = target.transform.position;
        float angle = Mathf.Atan2((target.transform.position.y - transform.position.y), (target.transform.position.x - transform.position.x)) * Mathf.Rad2Deg;
        spike.transform.eulerAngles = new Vector3(0.0f, 0.0f, angle + 90.0f);
        float scale = (transform.position - spike.transform.position).magnitude / 2.0f;
        spike.transform.localScale = new Vector3(scale, scale, scale);
    }
}
