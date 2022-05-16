using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameStart;

    [SerializeField] private float animDuration = 1f;

    [SerializeField] private Animator phoneUI;

    [Header("Triggers")]
    [SerializeField] private GameObject chat1a;
    [SerializeField] private GameObject chat1b;
    [SerializeField] private GameObject roomActivity;
    [SerializeField] private GameObject photoAlbum;
    [SerializeField] private GameObject chat2;
    [SerializeField] private GameObject snackActivity;
    [SerializeField] private GameObject chat3;
    [SerializeField] private GameObject chat4;
    [SerializeField] private GameObject chat5;
    [SerializeField] private GameObject breathingActivity;

    [Header("Chats")]
    [SerializeField] private GameObject messaging1a;
    [SerializeField] private GameObject messaging1b;

    void Awake()
    {
        if (!gameStart)
        {
            instance = this;
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            gameStart = true;

            // initialise triggers
            chat1a.SetActive(true);
            chat1b.SetActive(false);
            roomActivity.SetActive(false);
            photoAlbum.SetActive(false);
            chat2.SetActive(false);
            snackActivity.SetActive(false);
            chat3.SetActive(false);
            chat4.SetActive(false);
            chat5.SetActive(false);
            breathingActivity.SetActive(false);
        }
    }

    private void Update()
    {
        // check if the triggers still exist/dont exist. (after they are interacted with they are destroyed)
        // activate next activity based on this
        if(!chat1a && chat1b)
            chat1b.SetActive(true);
        
        if (!chat1b && roomActivity)
            roomActivity.SetActive(true);

        if(!roomActivity && photoAlbum)
            photoAlbum.SetActive(true);

        if(!photoAlbum && chat2)
            chat2.SetActive(true);

        if(!chat2 && snackActivity)
            snackActivity.SetActive(true);

        if(!snackActivity && chat3)
            chat3.SetActive(true);

        if(!chat3 && chat4)
            chat4.SetActive(true);

        if (!chat4 && chat5)
            chat5.SetActive(true);

        if (!chat5)
            breathingActivity.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!chat1a && chat1b)
            {
                Debug.Log("show chat 1 a");
                messaging1a.SetActive(true);
                phoneUI.SetBool("Notif", false);
            }
            else if (!chat1b && chat2)
            {
                Debug.Log("show chat 1 b");
                messaging1b.SetActive(true);
                phoneUI.SetBool("Notif", false);
            }
            else
            {
                Debug.Log("no phone");
                // internal dialogue "i need to find my phone first"
            }
        }
    }

    public void UnloadScene(int scene)
    {
        StartCoroutine(Unload(scene));
    }

    IEnumerator Unload(int scene)
    {
        yield return new WaitForSeconds(animDuration);

        SceneManager.UnloadScene(scene);
    }
}
