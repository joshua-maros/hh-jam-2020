using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Friend1Follow : MonoBehaviour
{
    public float speed;

    private Transform target;
    public Animator anim = null;

    private GameObject mainplayer;
    private GameObject friend2;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        mainplayer = GlobalData.instance.mainPlayer.gameObject;
        friend2 = GlobalData.instance.friend2.gameObject;
        anim.SetFloat("Speed", 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (friend2 != null)
            Physics2D.IgnoreCollision(mainplayer.GetComponent<Collider2D>(), friend2.GetComponent<Collider2D>());
        float distance = Vector2.Distance(transform.position, target.position);
        if (distance > 1.7f)
        {
            anim.SetBool("Walking", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, Mathf.Clamp01(distance - 1.2f) * speed * Time.deltaTime);
            if (target.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }

    private IEnumerator DeathSequence()
    {
        GlobalData.instance.DoLightning();
        // Wait for the second blackout frame.
        while (!GlobalData.instance.blackoutNow) yield return null;
        while (GlobalData.instance.blackoutNow) yield return null;
        while (!GlobalData.instance.blackoutNow) yield return null;
        transform.position = new Vector2(0.0f, -10000.0f);
        yield return new WaitForSeconds(1.0f);
        // Maybe add something here.
        Destroy(gameObject);
    }

    public void StartDeathSequence()
    {
        StartCoroutine("DeathSequence");
    }
}
