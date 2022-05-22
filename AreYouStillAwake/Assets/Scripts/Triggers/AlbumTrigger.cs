using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumTrigger : MonoBehaviour
{
    [SerializeField] private GameObject album;
    [SerializeField] private PlayerMovement player;

    bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        album.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                album.SetActive(true);
                player.freezePlayer = true;
                playerInRange = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
