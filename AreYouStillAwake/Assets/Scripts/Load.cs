using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    [SerializeField] private int sceneToLoad;
    [SerializeField] private int sceneToUnload;

    bool loaded;
    bool unloaded;

    void OnTriggerEnter2D()
    {
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
