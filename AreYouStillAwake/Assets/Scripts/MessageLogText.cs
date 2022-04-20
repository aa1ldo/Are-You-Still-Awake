using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageLogText : MonoBehaviour
{
    public void SetText(string myText)
    {
        GetComponentInChildren<TMPro.TMP_Text>().text = myText;
    }
}
