using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    private bool triggered = false;
    private ConversationPiece conversation = null;
    public List<string> conversationLines = new List<string>();
    public List<Speaker> conversationSpeakers = new List<Speaker>();

    // Start is called before the first frame update
    void Start()
    {
        ConversationPiece previousPiece = null;
        for (int i = 0; i < conversationLines.Count; i++)
        {
            ConversationPiece currentPiece = new ConversationPiece();
            if (previousPiece == null) 
                conversation = currentPiece;
            else
                previousPiece.next = currentPiece;
            currentPiece.text = conversationLines[i];
            currentPiece.speaker = conversationSpeakers[i];
            previousPiece = currentPiece;
        }
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

        GlobalData.instance.StartConversation(conversation);
    }
}
