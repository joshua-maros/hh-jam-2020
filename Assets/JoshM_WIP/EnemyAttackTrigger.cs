using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    private bool triggered = false;
    public EnemyAttack enemy = null;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
        if (player == null) return;
        triggered = true;

        enemy.StartAttack();
        sound.Play();
        GlobalData.instance.DoScreenShake(0.5f);
        StartCoroutine("DoAck");
    }

    private IEnumerator DoAck()
    {
        yield return new WaitForSeconds(0.1f);
        GlobalData.instance.mainPlayer.anim.SetBool("Struggling", true);
        yield return new WaitForSeconds(0.4f);
        ConversationPiece ack = new ConversationPiece();
        ack.text = "ACK!";
        ack.speaker = Speaker.Player;
        GlobalData.instance.StartConversation(ack);
    }
}
