using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunLog2 : MonoBehaviour
{
    // reference to the script that logs messages
    [SerializeField] private MessageLogControl logControl;

    [SerializeField] private float responseTime;
    [SerializeField] private float responseDelay;
    [SerializeField] private bool randomiseResponseTime;

    // lists of all messages as strings
    [SerializeField] private string[] myMsgs;
    [SerializeField] private string[] theirMsgs;

    // list of all the points at which messages will trigger
    [SerializeField] private int[] myTriggers;
    [SerializeField] private int[] theirTriggers;

    // a string to hold the current message to be displayed
    private string theirCurrentMsg;
    private string myCurrentMsg;

    // an int to track your positions
    private int myCurrentPos;
    private int theirCurrentPos;

    // an int to hold the next point that a message will be triggered
    private int theirNextTrigger;
    private int myNextTrigger;

    // int that looks to the next index of the trigger arrays
    private int theirTriggerIndex;
    private int myTriggerIndex;

    // tracking the convo progress
    private bool messagesLeft = true;

    // get a reference to the exit button to control when the player can leave
    [SerializeField] private Button exitButton;

    [SerializeField] private GameObject typingPrompt;

    private void Awake()
    {
        // initialise:
        myCurrentPos = 0;
        theirCurrentPos = 0;

        myTriggerIndex = 0;
        theirTriggerIndex = 0;

        myNextTrigger = myTriggers[myTriggerIndex];
        theirNextTrigger = theirTriggers[theirTriggerIndex];

        typingPrompt.SetActive(false);
    }

    private void Update()
    {
        if (!messagesLeft)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }

        if(theirCurrentPos == theirMsgs.Length && !messagesLeft)
        {
            // the conversation has ended, so allow the player to exit the chat
            exitButton.GetComponent<Button>().interactable = true;
        }
    }

    public void OnReply()
    {
        if (myCurrentPos == myNextTrigger)
        {
            // assume the player can still send messages:
            myCurrentMsg = myMsgs[myCurrentPos];
            logControl.LogText(myCurrentMsg); // log the player's message

            // if the player has finished displaying their messages, do not let them send anymore messages:
            if (myCurrentPos == myMsgs.Length - 1)
            {
                messagesLeft = false;
            }
            else
            {
                messagesLeft = false;
            }

            myCurrentPos++;

            myTriggerIndex++;

            if (myTriggerIndex > myTriggers.Length - 1)
            {
                myNextTrigger = 0;
                // there are no more triggers to look for now, so the code will default to displaying your messages normally
            }
            else
            {
                myNextTrigger = myTriggers[myTriggerIndex];
            }

            // start coroutine for friends messages
            StartCoroutine(OnFriend());
        }
        else
        {
            // assume the player can still send messages:
            myCurrentMsg = myMsgs[myCurrentPos];
            logControl.LogText(myCurrentMsg); // log the player's message

            // if the player has finished displaying their messages, do not let them send anymore messages:
            if (myCurrentPos == myMsgs.Length - 1)
            {
                messagesLeft = false;
                logControl.LogEnd();
            }

            myCurrentPos++;
        }
    }

    IEnumerator OnFriend()
    {
        while (theirCurrentPos <= theirNextTrigger)
        {
            theirCurrentMsg = theirMsgs[theirCurrentPos];

            // randomise a response time
            if (randomiseResponseTime)
            {
                responseTime = Random.Range(0.8f, 2f);
                responseDelay = Random.Range(0.2f, 0.5f);
            }

            yield return new WaitForSeconds(responseDelay);

            typingPrompt.SetActive(true);

            yield return new WaitForSeconds(responseTime);

            typingPrompt.SetActive(false);

            logControl.LogTextFriend(theirCurrentMsg); // log the friend's message

            if (theirCurrentPos >= theirMsgs.Length - 1)
            {
                messagesLeft = false;
            }
            else if (theirCurrentPos == theirNextTrigger)
            {
                messagesLeft = true;
            }

            theirCurrentPos++;
        }

        theirTriggerIndex++;

        if (theirTriggerIndex <= theirTriggers.Length - 1)
        {
            theirNextTrigger = theirTriggers[theirTriggerIndex];
        }

        if (!messagesLeft)
        {
            logControl.LogEnd();
        }
    }
}
