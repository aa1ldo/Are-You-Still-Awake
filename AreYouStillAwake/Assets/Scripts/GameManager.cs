using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameStart;

    [SerializeField] private float animDuration = 1f;

    [SerializeField] private Animator phoneUI;
    [SerializeField] private AudioSource notif;

    [SerializeField] private DialogueManager dialogueManager;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject player;

    [SerializeField] private Image fadeOverlay;
    [SerializeField] private Animator fadeAnimator;

    [SerializeField] private Animator roomActivityAnim;
    [SerializeField] private Animator snackActivityAnim;

    [Header("Triggers")]
    [SerializeField] private GameObject dialogue1;
    [SerializeField] private GameObject dialogue2a;
    [SerializeField] private GameObject dialogue2b;
    [SerializeField] private GameObject chat1a;
    [SerializeField] private GameObject dialogue3a;
    [SerializeField] private GameObject dialogue3b;
    [SerializeField] private GameObject chat1b;
    [SerializeField] private GameObject dialogue4;
    [SerializeField] private GameObject roomActivity;
    [SerializeField] private GameObject dialogue5;
    [SerializeField] private GameObject photoAlbum;
    [SerializeField] private GameObject chat2;
    [SerializeField] private GameObject dialogue6;
    [SerializeField] private GameObject dialogue7;
    [SerializeField] private GameObject dialogue8;
    [SerializeField] private GameObject snackActivity;
    [SerializeField] private GameObject chat3;
    [SerializeField] private GameObject hallucinationSceneTrigger;
    [SerializeField] private GameObject dialogue9;
    [SerializeField] private GameObject dialogue10;
    [SerializeField] private GameObject dialogue11;
    [SerializeField] private GameObject dialogue12;
    [SerializeField] private GameObject dialogue13;
    [SerializeField] private GameObject dialogue14a;
    [SerializeField] private GameObject chat4;
    [SerializeField] private GameObject dialogue14b;
    [SerializeField] private GameObject dialogue15;
    [SerializeField] private GameObject chat5;
    [SerializeField] private GameObject dialogue16a;
    [SerializeField] private GameObject dialogue16b;
    [SerializeField] private GameObject breathingActivity;

    [Header("UI")]
    [SerializeField] private GameObject messaging1a;
    [SerializeField] private GameObject messaging1b;
    [SerializeField] private GameObject messaging2;
    [SerializeField] private GameObject messaging3;
    [SerializeField] private GameObject messaging4;
    [SerializeField] private GameObject messaging5;
    [SerializeField] private GameObject photoAlbumCanvas;
    [SerializeField] private GameObject roomActivityCanvas;
    [SerializeField] private GameObject snackActivityCanvas;

    [SerializeField] private RunLog2 convoState1a;
    [SerializeField] private RunLog2 convoState1b;
    [SerializeField] private RunLog2 convoState2;
    [SerializeField] private RunLog2 convoState3;
    [SerializeField] private RunLog2 convoState4;
    [SerializeField] private RunLog2 convoState5;
    [SerializeField] private AlbumDisplay photoAlbumState;

    bool fadeDone1;
    bool fadeDone2;
    bool fadeDone3;

    bool loadedClean;
    bool unloadedMessy;

    [HideInInspector] public bool completedRoomActivity;
    [HideInInspector] public bool completedSnackActivity;

    void Awake()
    {
        if (!gameStart)
        {
            instance = this;
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            gameStart = true;

            // initialise triggers
            dialogue1.SetActive(true);
            dialogue2a.SetActive(false);
            dialogue2b.SetActive(false);
            chat1a.SetActive(false);
            dialogue3a.SetActive(false);
            dialogue3b.SetActive(false);
            chat1b.SetActive(false);
            dialogue4.SetActive(false);
            roomActivity.SetActive(false);
            dialogue5.SetActive(false);
            photoAlbum.SetActive(false);
            chat2.SetActive(false);
            dialogue6.SetActive(false);
            dialogue7.SetActive(false);
            dialogue8.SetActive(false);
            snackActivity.SetActive(false);
            chat3.SetActive(false);
            hallucinationSceneTrigger.SetActive(false);
            dialogue9.SetActive(false);
            dialogue10.SetActive(false);
            dialogue11.SetActive(false);
            dialogue12.SetActive(false);
            dialogue13.SetActive(false);
            dialogue14a.SetActive(false);
            chat4.SetActive(false);
            dialogue14b.SetActive(false);
            dialogue15.SetActive(false);
            chat5.SetActive(false);
            dialogue16a.SetActive(false);
            dialogue16b.SetActive(false);
            breathingActivity.SetActive(false);

            fadeDone1 = false;
            fadeDone2 = false;
            fadeDone3 = false;

            completedRoomActivity = false;
            completedSnackActivity = false;

            roomActivityCanvas.SetActive(true);
            snackActivityCanvas.SetActive(true);
        }
    }

    private void Update()
    {
        // check if the triggers still exist/dont exist. (after they are interacted with they are destroyed)
        // activate next activity based on this

        // states:
        /*
        dialogueManager.isOpen (check if dialogue is playing)
        convoStateX.convoDone (check if the convo specified is finished)
         */

        if (!dialogue1 && dialogue2a && !dialogueManager.isOpen)
        {
            dialogue2a.SetActive(true);
        }

        if (!dialogue2a && dialogue2b && !dialogueManager.isOpen)
        {
            dialogue2b.SetActive(true);
        }

        if (!dialogue2b && chat1a && !dialogueManager.isOpen)
        {
            chat1a.SetActive(true);
        }

        if (!chat1a && convoState1a.convoDone && dialogue3a && !fadeDone1)
        {
            StartCoroutine(Fading1());
            fadeDone1 = true;
        }

        if(!dialogue3a && dialogue3b && !dialogueManager.isOpen && fadeDone1)
        {
            dialogue3b.SetActive(true);
        }

        if(!dialogue3b && chat1b && !dialogueManager.isOpen)
        {
            chat1b.SetActive(true);
        }

        if(!chat1b && convoState1b.convoDone && dialogue4)
        {
            dialogue4.SetActive(true);
        }

        if(!dialogue4 && roomActivity && !dialogueManager.isOpen)
        {
            roomActivity.SetActive(true);
        }

        if (completedRoomActivity && snackActivity)
        {
            if (!loadedClean)
            {
                SceneManager.LoadSceneAsync("Bedroom-Clean", LoadSceneMode.Additive);
                loadedClean = true;
            }

            if (!unloadedMessy)
            {
                SceneManager.UnloadSceneAsync("Bedroom-Messy");
                unloadedMessy = true;
            }
            roomActivityAnim.SetBool("Fade", false);
            playerMovement.freezePlayer = false;
        }

        if(!roomActivity && dialogue5 && !dialogueManager.isOpen)
        {
            dialogue5.SetActive(true);
        }

        if(!dialogue5 && photoAlbum && !dialogueManager.isOpen)
        {
            photoAlbum.SetActive(true);
        }

        if(photoAlbumState.finishedAlbum && chat2 && !photoAlbumCanvas.activeSelf)
        {
            chat2.SetActive(true);
        }

        if(!chat2 && dialogue6 && convoState2.convoDone)
        {
            dialogue6.SetActive(true);
        }

        if(!dialogue6 && dialogue7 && !dialogueManager.isOpen)
        {
            dialogue7.SetActive(true);
        }

        if(!dialogue7 && dialogue8 && !dialogueManager.isOpen)
        {
            dialogue8.SetActive(true);
        }

        if (!dialogue8 && snackActivity && !dialogueManager.isOpen)
        {
            snackActivity.SetActive(true);
        }

        if (completedSnackActivity && !roomActivity)
        {
            snackActivityAnim.SetBool("Fade", false);
            playerMovement.freezePlayer = false;
        }

        if(completedSnackActivity && chat3 && !snackActivity)
        {
            chat3.SetActive(true);
        }

        if(convoState3.convoDone && !chat3 && dialogue9)
        {
            hallucinationSceneTrigger.SetActive(true);
            dialogue9.SetActive(true);
        }

        if(!dialogue9 && dialogue10)
        {
            dialogue10.SetActive(true);
            playerMovement.maxSpeed = 2.5f;
        }

        if(!dialogue10 && dialogue11)
        {
            dialogue11.SetActive(true);
            playerMovement.maxSpeed = 2f;
        }

        if (!dialogue11 && dialogue12)
        {
            dialogue12.SetActive(true);
            playerMovement.maxSpeed = 1.5f;
        }

        if (!dialogue12 && dialogue13)
        {
            dialogue13.SetActive(true);
            playerMovement.maxSpeed = 1f;
        }

        if (!dialogue13 && dialogue14a)
        {
            dialogue14a.SetActive(true);
            playerMovement.maxSpeed = 0.5f;
        }

        if(!dialogue14a && chat4 && !dialogueManager.isOpen)
        {
            chat4.SetActive(true);
            playerMovement.maxSpeed = 0f;
        }

        if (!chat4 && convoState4.convoDone && dialogue14b && !fadeDone2)
        {
            StartCoroutine(Fading2());
            fadeDone2 = true;
        }

        if(fadeDone2 && dialogue15)
        {
            dialogue15.SetActive(true);
        }

        if(!dialogue15 && chat5 && !dialogueManager.isOpen)
        {
            chat5.SetActive(true);
        }

        if(convoState5.convoDone && !fadeDone3 && dialogue16a)
        {
            StartCoroutine(Fading3());
            fadeDone3 = true;
        }




        // handle opening your phone
        if (Input.GetKeyDown(KeyCode.Space) && !dialogueManager.isOpen)
        {
            if (!chat1a && chat1b)
            {
                messaging1a.SetActive(true);
                phoneUI.SetBool("Notif", false);
                notif.Stop();
            }
            else if (!chat1b && chat2)
            {
                messaging1b.SetActive(true);
                phoneUI.SetBool("Notif", false);
                notif.Stop();
            }
            else if (!chat2 && chat3)
            {
                messaging2.SetActive(true);
                phoneUI.SetBool("Notif", false);
                notif.Stop();
            }
            else if (!chat3 && chat4)
            {
                messaging3.SetActive(true);
                phoneUI.SetBool("Notif", false);
                notif.Stop();
            }
            else if (!chat4 && chat5)
            {
                messaging4.SetActive(true);
                phoneUI.SetBool("Notif", false);
                notif.Stop();
            }
            else if (!chat5)
            {
                messaging5.SetActive(true);
                phoneUI.SetBool("Notif", false);
                notif.Stop();
            }
        }

        // handle closing your phone
        if(messaging1b.activeSelf && convoState1b.convoDone)
        {
            if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
            {
                messaging1b.SetActive(false);
            }
        }

        if (messaging2.activeSelf && convoState2.convoDone)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
            {
                messaging2.SetActive(false);
            }
        }

        if (messaging3.activeSelf && convoState3.convoDone)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
            {
                messaging3.SetActive(false);
            }
        }

        if (messaging4.activeSelf && convoState4.convoDone)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
            {
                messaging4.SetActive(false);
            }
        }

        if (messaging5.activeSelf && convoState5.convoDone)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
            {
                messaging5.SetActive(false);
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

    IEnumerator Fading1()
    {
        messaging1a.SetActive(false);
        fadeAnimator.SetBool("Fade", true);
        yield return new WaitUntil(() => fadeOverlay.color.a == 1);
        dialogue3a.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => !dialogueManager.isOpen);
        fadeAnimator.SetBool("Fade", false);
    }

    IEnumerator Fading2()
    {
        messaging4.SetActive(false);
        fadeAnimator.SetBool("Fade", true);
        yield return new WaitUntil(() => fadeOverlay.color.a == 1);
        dialogue14b.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        player.transform.position = new Vector2(4.5f, 6f);
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(10);
        yield return new WaitUntil(() => !dialogueManager.isOpen);
        fadeAnimator.SetBool("Fade", false);
        playerMovement.maxSpeed = 1.5f;
    }

    IEnumerator Fading3()
    {
        messaging5.SetActive(false);
        fadeAnimator.SetBool("Fade", true);
        yield return new WaitUntil(() => fadeOverlay.color.a == 1);
        dialogue16a.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => !dialogueManager.isOpen);
        // wait until blossom fade in
        dialogue16b.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => !dialogueManager.isOpen);
        SceneManager.LoadScene("Breathing");
    }
}
