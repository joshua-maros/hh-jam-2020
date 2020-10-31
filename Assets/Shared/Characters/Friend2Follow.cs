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

    private IEnumerator DeathSequence()
    {
        // Wait for the second blackout frame.
        while (!GlobalData.instance.blackoutNow) yield return null;
        while (GlobalData.instance.blackoutNow) yield return null;
        while (!GlobalData.instance.blackoutNow) yield return null;
        transform.position = new Vector2(0.0f, -10000.0f);
        yield return new WaitForSeconds(3.0f);
        ConversationPiece concern = new ConversationPiece();
        concern.text = "Wait, where'd FRIEND2 go?";
        concern.speaker = Speaker.Player;
        concern.next = new ConversationPiece();
        concern.next.text = "I think they went ahead.";
        concern.next.speaker = Speaker.Friend1;
        GlobalData.instance.StartConversation(concern);
        // If we destroy it before starting the convo the coroutine will be destroyed too.
        Destroy(gameObject);
    }

    public void StartDeathSequence()
    {
        StartCoroutine("DeathSequence");
    }
}
