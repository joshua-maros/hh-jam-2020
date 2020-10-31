using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{

    private Animator animator;
    private bool doorOpen;
    public bool Using;
    public bool Idling;


    // Start is called before the first frame update
    void Start()
    {
        doorOpen = false;
        Using = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Using = true;
        } else
        {
            Using = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && Using && !doorOpen)
        {
            doorOpen = true;
            Door("Open", Idling);
            Idling = false;
            animator.setBool("Idling", Idling);
        } else if (col.gameObject.tag == "Player" && Using && doorOpen)
        {
            doorOpen = false;
            Idling = true;
            Door("Close", Idling);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (doorOpen)
        {
            Using = false;
            doorOpen = false;
            Idling = true;
            Door("Close", Idling);
        }
    }

    void Door(string Direction, bool idleBool)
    {
        animator.SetTrigger(direction);
        animator.SetBool("Idling", Idling);
    }
}
