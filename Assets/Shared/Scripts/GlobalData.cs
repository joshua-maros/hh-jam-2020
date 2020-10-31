using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public Camera cam = null;
    public PlayerMovement mainPlayer = null;
    public Friend1Follow friend1 = null;
    public Friend2Follow friend2 = null;
    public static GlobalData instance = null;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
