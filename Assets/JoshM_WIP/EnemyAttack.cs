using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator anim = null;
    private int health = 6;
    private bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    public void StartAttack()
    {
        anim.SetTrigger("Attack");
        attacking = true;
    }

    private IEnumerator Conversation()
    {
        yield return new WaitForSeconds(0.8f);
        ConversationPiece panic = new ConversationPiece();
        panic.text = "I want to get out of here.";
        panic.speaker = Speaker.Player;
        panic.next = new ConversationPiece();
        panic.next.text = "Yeah, let's leave.";
        panic.next.speaker = Speaker.Friend1;
        GlobalData.instance.StartConversation(panic);
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            if (GlobalData.instance.useWasPressed)
            {
                if (health > 0) GlobalData.instance.DoScreenShake(0.3f);
                health -= 1;
                if (health == 0)
                {
                    anim.SetTrigger("Die");
                    // Detach from player.
                    transform.parent = null;
                    GlobalData.instance.ActivateRoom3Recursion();
                    GlobalData.instance.mainPlayer.anim.SetBool("Struggling", false);
                    StartCoroutine("Conversation");
                }
            }
        }
    }
}
