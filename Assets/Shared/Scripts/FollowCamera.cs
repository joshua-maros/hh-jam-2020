using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target = null;
    // Turn this on to follow the player even if they are going very fast.
    public bool superspeed = false;
    public float screenshake = 0.0f;
    public float shakeDecay = 10.0f;
    public float shakeMagnitude = 20.0f;
    private Vector3 shakeOffset = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 2.0f;
        Vector3 newPos = Vector3.Lerp(transform.position - shakeOffset, target.transform.position, Time.deltaTime * speed);
        if ((target.transform.position - transform.position - shakeOffset).magnitude < 0.05f || superspeed) {
            newPos = target.transform.position;
        }
        newPos.z = transform.position.z;
        if (screenshake > 0)
        {
            float m = screenshake * shakeMagnitude;
            shakeOffset = new Vector3(Random.Range(-m, m), Random.Range(-m, m), 0);
            screenshake -= shakeDecay * Time.deltaTime;
        }
        else
        {
            shakeOffset = new Vector3(0, 0, 0);
        }

        transform.position = newPos + shakeOffset;
    }
}
