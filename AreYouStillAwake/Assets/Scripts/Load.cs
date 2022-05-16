using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    [SerializeField] private Image black;
    [SerializeField] private Animator anim;

    [SerializeField] private int sceneToLoad;
    [SerializeField] private int sceneToUnload;

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
            SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

            loaded = true;
        }

        if (!unloaded)
        {
            unloaded = true;

            GameManager.instance.UnloadScene(sceneToUnload);
        }
    }
}
