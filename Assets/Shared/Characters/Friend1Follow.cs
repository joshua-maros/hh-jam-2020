﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Friend1Follow : MonoBehaviour
{
    public float speed;

    private Transform target;

    private GameObject mainplayer;
    private GameObject friend2;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        mainplayer = GlobalData.instance.mainPlayer.gameObject;
        friend2 = GlobalData.instance.friend2.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(mainplayer.GetComponent<Collider2D>(), friend2.GetComponent<Collider2D>());
        if (Vector2.Distance(transform.position, target.position) > 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
