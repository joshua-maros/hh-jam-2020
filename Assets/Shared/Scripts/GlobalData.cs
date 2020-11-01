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
    private FollowCamera realCam = null;
    public PlayerMovement mainPlayer = null;
    public Friend1Follow friend1 = null;
    public Friend2Follow friend2 = null;
    public SpeechBubble speechBubblePrefab = null;
    public bool useWasPressed = false;
    public static GlobalData instance = null;
    public GameObject beforeRoom3 = null, room3Recursion = null, recursionPivot = null, basementSpawn = null;
    public bool lightningNow = false, blackoutNow = false;
    public GameObject totalBlackout = null;
    public AudioSource thunder;

    private ConversationPiece currentConversation = null;
    private SpeechBubble currentSpeechBubble = null;
    private float bubbleTimer = 0.0f;

    private IEnumerator LightningImpl()
    {
        thunder.Play();
        for (int i = 0; i < 3; i++) {
            yield return new WaitForSeconds(0.1f);
            lightningNow = true;
            blackoutNow = false;
            if (i == 0) DoScreenShake(0.5f);
            yield return new WaitForSeconds(0.05f);
            lightningNow = false;
            blackoutNow = true;
        }
        blackoutNow = false;
    }

    public void DoLightning()
    {
        StartCoroutine("LightningImpl");
    }

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
        bubbleTimer = 0.0f;
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

    public void ActivateRoom3Recursion()
    {
        beforeRoom3.transform.position = new Vector3(0, 20, 0);
        room3Recursion.transform.position = new Vector3(0, 0, 0);
        mainPlayer.gameObject.transform.parent = recursionPivot.transform;
        friend1.gameObject.transform.parent = recursionPivot.transform;
    }

    private IEnumerator BasementTeleport()
    {
        blackoutNow = true;
        totalBlackout.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        mainPlayer.transform.parent = null;
        mainPlayer.transform.eulerAngles = new Vector3(0, 0, 0);
        mainPlayer.transform.position = basementSpawn.transform.position;
        yield return new WaitForSeconds(2.5f);
        totalBlackout.SetActive(false);
        blackoutNow = false;
    }

    public void EnterBasement()
    {
        StartCoroutine("BasementTeleport");
    }

    public void DoScreenShake(float amount)
    {
        realCam.screenshake = amount;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        realCam = cam.GetComponent<FollowCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        useWasPressed = Input.GetButtonDown("Use");
        bubbleTimer += Time.deltaTime;
        // Prevent the user from accidentally pressing advance twice.
        if (Input.GetButtonDown("AdvanceSpeech") && bubbleTimer > 1.0f)
        {
            if (currentConversation != null)
            {
                currentConversation = currentConversation.next;
                ConfigureSpeechBubble();
            }
        }
    }
}
