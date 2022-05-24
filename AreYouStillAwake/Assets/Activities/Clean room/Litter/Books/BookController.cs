using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookController : MonoBehaviour
{
    public BlueBooks blueCheck;
    public RedBooks redCheck;
    public GameObject BooksOne;
    public GameObject BooksTwo;
    public Sprite redBooks;
    public Sprite blueBooks;

    int counter;
    bool countCheck1 = true;
    bool countCheck2 = true;

    bool isBlue;
    bool isRed;

    public bool booksCleaned;


    public void Start()
    {
        BooksOne.SetActive(false);
        BooksTwo.SetActive(false);
    }

    public void Update()
    {
        if (blueCheck.blueCleaned)
        {
            if (countCheck1)
            {
                counter += 1;
                countCheck1 = false;
            }
            if(counter == 1)
            {
                BooksOne.SetActive(true);
                BooksOne.GetComponent<Image>().sprite = blueBooks;
            }
            else if (counter == 2 && !isRed)
            {
                BooksTwo.SetActive(true);
                BooksTwo.GetComponent<Image>().sprite = blueBooks;
                isBlue = true;
            }
        }
        if (redCheck.redCleaned)
        {
            if (countCheck2)
            {
                counter += 1;
                countCheck2 = false;
            }
            if (counter == 1)
            {
                BooksOne.SetActive(true);
                BooksOne.GetComponent<Image>().sprite = redBooks;
            }
            else if (counter == 2 && !isBlue)
            {
                BooksTwo.SetActive(true);
                BooksTwo.GetComponent<Image>().sprite = redBooks;
                isRed = true;
            }
        }

        if (blueCheck.blueCleaned && redCheck.redCleaned)
        {
            booksCleaned = true;
        }
    }
}
