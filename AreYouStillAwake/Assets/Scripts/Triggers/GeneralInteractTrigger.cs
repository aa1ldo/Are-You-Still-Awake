using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralInteractTrigger : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    [SerializeField] private GameObject toOpen;
    [SerializeField] private PlayerMovement player;

    bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        toOpen.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange)
        {
            // visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Z))
            {
                /*
                toOpen.SetActive(true);
                player.freezePlayer = true;
                playerInRange = false;
                visualCue.SetActive(false);
                Destroy(gameObject);
                */
            }
        }
        else
        {
            // visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.newChat = true;
            Destroy(gameObject);
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
    */
}
