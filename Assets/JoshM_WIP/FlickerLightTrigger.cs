using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLightTrigger : MonoBehaviour
{
    private bool triggered = false;
    public new FlickerableLight light = null;
    public float flickerTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
        if (player == null) return;
        triggered = true;

        light.DoFlickers(flickerTime);
    }
}
