using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Barcontroller : MonoBehaviour
{
    Image completionBar;

    public W1 w1;
    public W2 w2;
    public W3 w3;
    public W4 w4;
    public W5 w5;

    public DeskClean deskCheck;
    public BookController bookCheck;

    bool counterAdding1 = true;
    bool counterAdding2 = true;
    bool counterAdding3 = true;
    bool counterAdding4 = true;
    bool counterAdding5 = true;
    bool counterAdding6 = true;
    bool counterAdding7 = true;
    //
    bool counterAdded1;
    bool counterAdded2;
    bool counterAdded3;
    bool counterAdded4;
    bool counterAdded5;
    bool counterAdded6;
    bool counterAdded7;
    //
    int counter;


    float progress = 0f;

    private void Start()
    {
        completionBar = GetComponent<Image>();
    }

    private void Update()
    {
        completionBar.fillAmount = Mathf.Lerp(0, 1, progress);

        if (w1.pressed1)
        {
            if (counterAdding1)
            {
                counter += 1;
                counterAdding1 = false;
            }
        }
        if (w2.pressed2)
        {
            if (counterAdding2)
            {
                counter += 1;
                counterAdding2 = false;
            }
        }
        if (w3.pressed3)
        {
            if (counterAdding3)
            {
                counter += 1;
                counterAdding3 = false;
            }
        }
        if (w4.pressed4)
        {
            if (counterAdding4)
            {
                counter += 1;
                counterAdding4 = false;
            }
        }
        if (w5.pressed5)
        {
            if (counterAdding4)
            {
                counter += 1;
                counterAdding4 = false;
            }
        }
        if (deskCheck.cleanedDesk)
        {
            if (counterAdding4)
            {
                counter += 1;
                counterAdding4 = false;
            }
        }
        if (bookCheck.booksCleaned)
        {
            if (counterAdding4)
            {
                counter += 1;
                counterAdding4 = false;
            }
        }
        //
        if(counter == 1)
        {
            counterAdded1 = true;
        }
        if(counter == 2)
        {
            counterAdded2 = true;
        }
        if(counter == 3)
        {
            counterAdded3 = true;
        }
        if(counter == 4)
        {
            counterAdded4 = true;
        }
        if(counter == 5)
        {
            counterAdded5 = true;
        }
        if(counter == 6)
        {
            counterAdded6 = true;
        }
        if (counter == 7)
        {
            counterAdded7 = true;
        }
        //
        if (counterAdded1)
        {
            if(progress < 0.15)
            {
                progress = Time.deltaTime;
            }
            else
            {
                counterAdded1 = false;
            }
        }
    }
}
