using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Speaker
{
    Player,
    Friend1,
    Friend2,
}

public class ConversationPiece
{
    public Speaker speaker = Speaker.Player;
    public string text = "Hello World";
    public ConversationPiece next = null;
}

public class GlobalData : MonoBehaviour
{
    public Camera cam = null;
    public PlayerMovement mainPlayer = null;
    public Friend1Follow friend1 = null;
    public Friend2Follow friend2 = null;
    public SpeechBubble speechBubblePrefab = null;
    public static GlobalData instance = null;

    private ConversationPiece currentConversation = null;
    private SpeechBubble currentSpeechBubble = null;

    private GameObject GetSpeakerObject(Speaker speaker) 
    {
        if (speaker == Speaker.Player) return this.mainPlayer.gameObject;
        if (speaker == Speaker.Friend1) return this.friend1.gameObject;
        if (speaker == Speaker.Friend2) return this.friend2.gameObject;
        return null;
    }

    private void MakeNewSpeechBubble()
    {
        GameObject speaker = GetSpeakerObject(currentConversation.speaker);
        currentSpeechBubble = Instantiate(
            speechBubblePrefab, 
            speaker.transform.position + Vector3.up * 3.0f, 
            Quaternion.identity
        );
    }

    private void ConfigureSpeechBubble()
    {
        if (currentConversation == null)
        {
            Destroy(currentSpeechBubble.gameObject);
        }
        else
        {
            currentSpeechBubble.ShowText(currentConversation.text);
            currentSpeechBubble.target = GetSpeakerObject(currentConversation.speaker);
        }
    }

    public void StartConversation(ConversationPiece root)
    {
        currentConversation = root;
        if (currentSpeechBubble == null)
        {
            MakeNewSpeechBubble();
        }
        ConfigureSpeechBubble();
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("AdvanceSpeech"))
        {
            if (currentConversation != null)
            {
                currentConversation = currentConversation.next;
                ConfigureSpeechBubble();
            }
        }
    }
}
