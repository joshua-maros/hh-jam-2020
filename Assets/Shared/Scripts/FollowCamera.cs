using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * 2.0f);
        if ((target.transform.position - transform.position).magnitude < 0.05f) {
            newPos = target.transform.position;
        }
        newPos.z = transform.position.z;
        transform.position = newPos;
    }
}
