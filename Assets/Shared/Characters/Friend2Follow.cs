using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Friend2Follow : MonoBehaviour
{
    public float speed;

    private Transform target;

    private GameObject mainplayer;
    private GameObject friend1;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Friend1").GetComponent<Transform>();
        mainplayer = GlobalData.instance.mainPlayer.gameObject;
        friend1 = GlobalData.instance.friend1.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(mainplayer.GetComponent<Collider2D>(), friend1.GetComponent<Collider2D>());
        if (Vector2.Distance(transform.position, target.position) > 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void StartDeathSequence()
    {
        // TODO: Add drama :P
        Destroy(gameObject);
        // GlobalData.instance.StartConversation(null);
        ConversationPiece concern = new ConversationPiece();
        concern.text = "FRIEND2?";
        concern.speaker = Speaker.Player;
        concern.next = new ConversationPiece();
        concern.next.text = "Where'd you go, FRIEND2?";
        concern.next.speaker = Speaker.Friend1;
        GlobalData.instance.StartConversation(concern);
    }
}
