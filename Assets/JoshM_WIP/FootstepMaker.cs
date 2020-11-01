using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepMaker : MonoBehaviour
{
    public AudioClip[] stepSounds;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayStep()
    {
        source.clip = stepSounds[Random.Range(0, stepSounds.Length)];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
