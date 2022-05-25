using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Animator anim;
    public void PlayButton()
    {
        StartCoroutine(Play());
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    IEnumerator Play()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => image.color.a == 1);
        SceneManager.LoadScene("NeverUnload");
    }
}
