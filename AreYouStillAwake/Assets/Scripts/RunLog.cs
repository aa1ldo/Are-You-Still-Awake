using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RunLog : MonoBehaviour
{
    [SerializeField]
    private string[] myTextMessages;

    private string myTextMessage;

    [SerializeField]
    private string[] friendTextMessages;

    private string friendTextMessage;



    [SerializeField]
    private int[] friendTriggerPos;

    [SerializeField]
    private int[] myTriggerPos;

    int myTargetPos;
    int myCurrentPos = 0;

    int x = 0;
    int friendTargetPos;
    int friendCurrentPos = 0;

    int myNextTarget = 0; // use this in friendTriggerPos[   here   ]
    int friendNextTarget = 0; // use this in myTriggerPos[   here   ]

    [SerializeField]
    private MessageLogControl logControl;

    private void Start()
    {
        friendTargetPos = myTriggerPos[friendNextTarget] - 1; // initialise the target message position that when reached will allow you to send messages
        myTargetPos = friendTriggerPos[myNextTarget] - 1; // initialise the target message position that will trigger friend's messages
    }


    public void LogText() // function called when the player presses the button it is attached to
    {
        if (myCurrentPos == myTargetPos) // if you reach the target position
        {
            Debug.Log("Current position: " + myCurrentPos);
            Debug.Log("Target position: " + myTargetPos);

            if (myNextTarget < friendTriggerPos.Length) // checks whether your next target is still within the array
            {
                myNextTarget++; // increment your next target position
            }

            myTargetPos = friendTriggerPos[myNextTarget - 1]; // sets your target position to the target position within the array

            gameObject.GetComponent<Button>().interactable = false; // disables the button UI from being pressed

            StartCoroutine(LogFriendText()); // starts displaying the friends messages
        } else if(myCurrentPos != myTargetPos) // if you do not reach the target position
        {
            Debug.Log("Current position: " + myCurrentPos);
            Debug.Log("Target position: " + myTargetPos);

            myTextMessage = myTextMessages[myCurrentPos]; // sets your message to be displayed to the message within the array

            logControl.LogText(myTextMessage); // calls the LogText function in another script ("MessageLogControl") to log your message

            myCurrentPos++; // increments your current position
        } else
        {
            Debug.Log("!!!!");
        }
    }

    IEnumerator LogFriendText()
    {
        for (x = friendCurrentPos; x < friendTargetPos; x++) // sets x to the friend's current message position, cycles through until you reach the friend's target position
        {
            yield return new WaitForSeconds(1f); // waits a second before their message is displayed

            friendTextMessage = friendTextMessages[x]; // sets the friend's text message to the message within the array

            logControl.LogTextFriend(friendTextMessage); // calls the LogText function in another script ("MessageLogControl") to log your friends message
        }

        friendCurrentPos = x; // update the friend's current message position

        if (friendNextTarget < myTriggerPos.Length) // checks whether your friend's next target is within the array
        {
            friendNextTarget++; // increments their next target
            friendTargetPos = myTriggerPos[friendNextTarget - 1]; // sets your friend's next target position to the next one within the array
        }

        gameObject.GetComponent<Button>().interactable = true; // allows the player to press the reply button
    }
}
