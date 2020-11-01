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

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            if (GlobalData.instance.useWasPressed)
            {
                health -= 1;
                GlobalData.instance.DoScreenShake(0.3f);
                if (health == 0)
                {
                    anim.SetTrigger("Die");
                    // Detach from player.
                    transform.parent = null;
                    ConversationPiece panic = new ConversationPiece();
                    panic.text = "We need to get out of here.";
                    panic.speaker = Speaker.Player;
                    panic.next = new ConversationPiece();
                    panic.next.text = "Yeah, let's leave.";
                    panic.next.speaker = Speaker.Friend1;
                    GlobalData.instance.StartConversation(panic);
                    GlobalData.instance.ActivateRoom3Recursion();
                }
            }
        }
    }
}
