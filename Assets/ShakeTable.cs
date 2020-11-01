using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTable : MonoBehaviour
{
    private Vector3 basepos;

    // Start is called before the first frame update
    void Start()
    {
        basepos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float strength = 0.05f;
        transform.position = basepos + new Vector3(
            strength * Random.Range(-1.0f, 1.0f),
            strength * Random.Range(-1.0f, 1.0f),
            0.0f
        );
    }
}
