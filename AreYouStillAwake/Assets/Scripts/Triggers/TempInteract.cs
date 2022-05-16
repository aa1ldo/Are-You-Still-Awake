using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempInteract : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;

    [Header("Activity - pick 1")]
    [SerializeField] private bool roomClearingActivity;
    [SerializeField] private bool snackMakingActivity;

    bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (roomClearingActivity)
                {
                    SceneManager.LoadSceneAsync("RoomCleaning", LoadSceneMode.Additive);
                }
                visualCue.SetActive(false);
                Destroy(gameObject);
            }
        }
        else
        {
            visualCue.SetActive(false);
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
