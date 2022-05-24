using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivityTrigger : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator roomClearingAnim;
    [SerializeField] private Animator snackMakingAnim;
    [SerializeField] private AudioSource ambience;

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
                    roomClearingAnim.SetBool("Fade", true);
                    playerMovement.freezePlayer = true;
                }
                else
                {
                    snackMakingAnim.SetBool("Fade", true);
                    playerMovement.freezePlayer = true;
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
