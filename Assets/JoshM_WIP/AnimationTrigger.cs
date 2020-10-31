using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private bool triggered = false;
    public Animator anim = null;

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

        anim.SetTrigger("Go");
    }
}
