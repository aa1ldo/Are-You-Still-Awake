using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageLeft : MonoBehaviour
{
    [SerializeField] private AlbumDisplay page;
    public bool buttonPressed;

    private void Awake()
    {
        gameObject.GetComponent<Button>().interactable = false;
        buttonPressed = false;
    }

    private void Update()
    {
        if(page.currentPage == 1)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void LeftPressed()
    {
        page.currentPage -= 1;
        buttonPressed = true;
    }
}
