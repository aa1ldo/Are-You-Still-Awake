using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumDisplay : MonoBehaviour
{
    public GameObject[] pageContents;
    public int currentPage = 1;

    [SerializeField] private PageRight rightButton;
    [SerializeField] private PageLeft leftButton;

    [HideInInspector] public bool finishedAlbum;

    private void Start()
    {
        finishedAlbum = false;
    }
    private void Awake()
    {
        for (int i = 1; i < pageContents.Length; i++)
        {
            pageContents[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (rightButton.buttonPressed || leftButton.buttonPressed)
        {
            for (int i = 0; i < pageContents.Length; i++)
            {
                pageContents[i].SetActive(false);
            }

            pageContents[currentPage - 1].SetActive(true);
        }

        if(currentPage == pageContents.Length)
        {
            finishedAlbum = true;
        }

        if (finishedAlbum)
        {
            if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
            {
                transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
