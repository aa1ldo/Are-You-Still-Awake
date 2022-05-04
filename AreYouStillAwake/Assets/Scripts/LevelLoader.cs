using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    public IEnumerator LoadLevel(int loadIndex, int unloadIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(loadIndex, LoadSceneMode.Additive);
        GameManager.instance.UnloadScene(unloadIndex);
    }
}
