using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    // [SerializeField] private LevelLoader loader;
    [SerializeField] private int sceneToLoad;
    [SerializeField] private int sceneToUnload;

    bool loaded;
    bool unloaded;

    void OnTriggerEnter2D()
    {
        if (!loaded)
        {
            // call the external function to play the loading animation

            // StartCoroutine(loader.LoadLevel(sceneToLoad, sceneToUnload));

            SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

            loaded = true;
        }

        if (!unloaded)
        {
            unloaded = true;

            // call the external function to play the loading animation

            GameManager.instance.UnloadScene(sceneToUnload);
        }
    }
}
