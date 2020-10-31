using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObjectA;

    private IDoor doorA;

    private void Awake()
    {
        doorA = doorGameObjectA.GetComponent<IDoor>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            doorA.OpenDoor();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            doorA.CloseDoor();
        }
    }
}
