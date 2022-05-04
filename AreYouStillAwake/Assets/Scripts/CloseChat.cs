using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseChat : MonoBehaviour
{
    [SerializeField] private OpenChat chat;

    public void Exit()
    {
        transform.parent.gameObject.SetActive(false);
        chat.freezePlayer = false;
    }
}
