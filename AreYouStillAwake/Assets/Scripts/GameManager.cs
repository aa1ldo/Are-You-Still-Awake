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
    [SerializeField] private GameObject dialogue1;
    [SerializeField] private GameObject dialogue2;
    [SerializeField] private GameObject chat1a;
    [SerializeField] private GameObject dialogue3;
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
    [SerializeField] private GameObject messaging2;
    [SerializeField] private GameObject messaging3;
    [SerializeField] private GameObject messaging4;
    [SerializeField] private GameObject messaging5;

    [SerializeField] private RunLog2 convoState1a;
    [SerializeField] private RunLog2 convoState1b;
    [SerializeField] private RunLog2 convoState2;
    [SerializeField] private RunLog2 convoState3;
    [SerializeField] private RunLog2 convoState4;
    [SerializeField] private RunLog2 convoState5;

    void Awake()
    {
        if (!gameStart)
        {
            instance = this;
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            gameStart = true;

            // initialise triggers
            dialogue1.SetActive(true);
            dialogue2.SetActive(false);
            chat1a.SetActive(false);
            dialogue3.SetActive(false);
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

        // CURRENTLY NOT WORKING LOL:

        if (!dialogue1 && dialogue2)
            dialogue2.SetActive(true);

        if (!dialogue2 && chat1a)
            chat1a.SetActive(true);

        if (!chat1a && dialogue3)
            dialogue3.SetActive(true);

        if(!dialogue3 && chat1b && convoState1a.convoDone)
            chat1b.SetActive(true);
        
        if (!chat1b && roomActivity && convoState1b.convoDone)
            roomActivity.SetActive(true);

        if(!roomActivity)
            photoAlbum.SetActive(true);

        if(!roomActivity && chat2 && convoState1b.convoDone)
            chat2.SetActive(true);

        if(!chat2 && snackActivity && convoState2.convoDone)
            snackActivity.SetActive(true);

        if(!snackActivity && chat3 && convoState2.convoDone)
            chat3.SetActive(true);

        if(!chat3 && chat4 && convoState3.convoDone)
            chat4.SetActive(true);

        if (!chat4 && chat5 && convoState4.convoDone)
            chat5.SetActive(true);

        if (!chat5 && convoState5.convoDone)
            breathingActivity.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!chat1a && chat1b)
            {
                messaging1a.SetActive(true);
                phoneUI.SetBool("Notif", false);
            }
            else if (!chat1b && chat2)
            {
                messaging1b.SetActive(true);
                phoneUI.SetBool("Notif", false);
            }
            else if (!chat2 && chat3)
            {
                messaging2.SetActive(true);
                phoneUI.SetBool("Notif", false);
            }
            else if (!chat3 && chat4)
            {
                messaging3.SetActive(true);
                phoneUI.SetBool("Notif", false);
            }
            else if (!chat4 && chat5)
            {
                messaging4.SetActive(true);
                phoneUI.SetBool("Notif", false);
            }
            else if (!chat5)
            {
                messaging5.SetActive(true);
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
