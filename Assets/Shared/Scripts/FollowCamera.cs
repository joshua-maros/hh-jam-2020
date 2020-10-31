using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target = null;
    // Turn this on to follow the player even if they are going very fast.
    public bool superspeed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = superspeed ? 20.0f : 2.0f;
        Vector3 newPos = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);
        if ((target.transform.position - transform.position).magnitude < 0.05f) {
            newPos = target.transform.position;
        }
        newPos.z = transform.position.z;
        transform.position = newPos;
    }
}
