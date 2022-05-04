using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumDisplay : MonoBehaviour
{
    public GameObject[] pageContents;
    public int currentPage = 1;

    [SerializeField] private PageRight rightButton;
    [SerializeField] private PageLeft leftButton;

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
    }
}
