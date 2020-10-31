using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTrigger : MonoBehaviour
{
    private bool triggered = false;

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

        GlobalData.instance.DoLightning();
    }
}
