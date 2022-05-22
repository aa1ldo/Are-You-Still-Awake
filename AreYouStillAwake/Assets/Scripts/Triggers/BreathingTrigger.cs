using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreathingTrigger : MonoBehaviour
{ 
    bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // disable player gameoject
                SceneManager.LoadSceneAsync("Breathing", LoadSceneMode.Single);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
