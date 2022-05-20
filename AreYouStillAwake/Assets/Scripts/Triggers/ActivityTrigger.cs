using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivityTrigger : MonoBehaviour
{
    [SerializeField] private GameObject roomClearingCanvas;
    [SerializeField] private GameObject snackMakingCanvas;

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
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (roomClearingActivity)
                {
                    roomClearingCanvas.SetActive(true);
                }
                else
                {
                    snackMakingCanvas.SetActive(true);
                }
                Destroy(gameObject);
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
