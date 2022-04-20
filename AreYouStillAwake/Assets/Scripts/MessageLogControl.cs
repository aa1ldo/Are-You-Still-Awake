using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageLogControl : MonoBehaviour
{
    [SerializeField]
    private GameObject myTextTemplate;

    [SerializeField]
    private GameObject friendTextTemplate;

    [SerializeField]
    private Transform content;

    public void LogText(string newMessage)
    {
        GameObject newText = Instantiate(myTextTemplate, content) as GameObject;
        newText.SetActive(true);

        newText.GetComponent<MessageLogText>().SetText(newMessage);
    }

    public void LogTextFriend(string newMessageFriend)
    {
        GameObject newTextFriend = Instantiate(friendTextTemplate, content) as GameObject;
        newTextFriend.SetActive(true);

        newTextFriend.GetComponent<MessageLogText>().SetText(newMessageFriend);
    }
}
