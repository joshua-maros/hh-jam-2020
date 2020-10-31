using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPivotUtil : MonoBehaviour
{
    public FollowCamera cam = null;

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
}
