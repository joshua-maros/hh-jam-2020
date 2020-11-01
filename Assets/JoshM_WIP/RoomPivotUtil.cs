using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPivotUtil : MonoBehaviour
{
    public FollowCamera cam = null;
    public AudioSource mainSound, preludePlayer;
    public AudioClip prelude1, prelude2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableCameraSuperspeed()
    {
        cam.superspeed = true;
    }

    public void DisableCameraSuperspeed()
    {
        cam.superspeed = false;
    }

    public void KillFriend1()
    {
        GlobalData.instance.friend1.StartDeathSequence();
    }

    public void BasementTeleport()
    {
        GlobalData.instance.EnterBasement();
    }

    public void PlayMainSound()
    {
        mainSound.Play();
    }

    public void PlayPrelude1()
    {
        preludePlayer.clip = prelude1;
        preludePlayer.Play();
    }

    public void PlayPrelude2()
    {
        preludePlayer.clip = prelude2;
        preludePlayer.Play();
    }
}
