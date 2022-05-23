using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadHallucination : MonoBehaviour
{
    [SerializeField] private Image black;
    [SerializeField] private Animator anim;

    bool loaded;
    bool unloaded;

    void OnTriggerEnter2D()
    {
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);

        if (!loaded)
        {
            SceneManager.LoadSceneAsync(10, LoadSceneMode.Additive);

            loaded = true;
        }

        if (!unloaded)
        {
            unloaded = true;

            SceneManager.UnloadScene(6);
        }

        anim.SetBool("Fade", false);

    }
}
