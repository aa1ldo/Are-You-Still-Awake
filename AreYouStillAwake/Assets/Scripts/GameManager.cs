using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    bool gameStart;

    [SerializeField] private float animDuration = 1f;

    void Awake()
    {
        if (!gameStart)
        {
            instance = this;

            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

            gameStart = true;
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
