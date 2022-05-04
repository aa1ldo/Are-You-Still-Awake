using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChat : MonoBehaviour
{
    [SerializeField] private GameObject chat;
    [SerializeField] private PlayerMovement player;

    public bool freezePlayer;
    float currentMoveSpeed;

    private void Start()
    {
        chat.SetActive(false);
        freezePlayer = false;
        currentMoveSpeed = player.moveSpeed;
    }

    private void Update()
    {
        if (freezePlayer)
        {
            player.moveSpeed = 0f;
        }
        else
        {
            player.moveSpeed = currentMoveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            chat.SetActive(true);
            freezePlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
