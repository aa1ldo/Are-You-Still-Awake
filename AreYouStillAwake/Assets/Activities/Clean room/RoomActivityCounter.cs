using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomActivityCounter : MonoBehaviour
{
    Text counter;
    float itemCounter = 7;

    public W1 w1;
    public W2 w2;
    public W3 w3;
    public W4 w4;
    public W5 w5;

    public DeskClean deskCheck;
    public BookController bookCheck;
    //
    bool minusOne = true;
    bool minusTwo = true;
    bool minusThree = true;
    bool minusFour = true;
    bool minusFive = true;
    bool minusSix = true;
    bool minusSeven = true;
    bool minusEight = true;

    public void Start()
    {
        counter = gameObject.GetComponent<Text>();
    }

    public void Update()
    {
        if (w1.pressed1)
        {
            if (minusOne)
            {
                itemCounter -= 1;
                minusOne = false;
            }
        }
        if (w2.pressed2)
        {
            if (minusTwo)
            {
                itemCounter -= 1;
                minusTwo = false;
            }
        }
        if (w3.pressed3)
        {
            if (minusThree)
            {
                itemCounter -= 1;
                minusThree = false;
            }
        }
        if (w4.pressed4)
        {
            if (minusFour)
            {
                itemCounter -= 1;
                minusFour = false;
            }
        }
        if (w5.pressed5)
        {
            if (minusFive)
            {
                itemCounter -= 1;
                minusFive = false;
            }
        }
        if (deskCheck.cleanedDesk)
        {
            if (minusSix)
            {
                itemCounter -= 1;
                minusSix = false;
            }
        }
        if (bookCheck.redCheck.redCleaned && !bookCheck.blueCheck.blueCleaned)
        {
            if (minusSeven)
            {
                itemCounter -= 0.5f;
                minusSeven = false;
            }
        }
        else if (!bookCheck.redCheck.redCleaned && bookCheck.blueCheck.blueCleaned)
        {
            if (minusSeven)
            {
                itemCounter -= 0.5f;
                minusSeven = false;
            }
        }
        if (bookCheck.booksCleaned)
        {
            if (minusEight)
            {
                itemCounter -= 0.5f;
                minusEight = false;
            }
        }

        counter.text = itemCounter.ToString();

    }
}
