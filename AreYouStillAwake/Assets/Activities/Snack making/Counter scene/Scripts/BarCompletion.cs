using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarCompletion : MonoBehaviour
{
    public Image completionBar;

    public Bread2UIscript bread2Check;
    public BreadUIscript breadCheck;
    public KnifeUIscript knifeCheck;
    public SprinkleUIscript sprinkleCheck;

    float progress = 0f;

    bool counterAdding1 = true;
    bool counterAdding2 = true;
    bool counterAdding3 = true;
    bool counterAdding4 = true;
    //
    bool counterAdded1;
    bool counterAdded2;
    bool counterAdded3;
    bool counterAdded4;
    int counter;

    void Start()
    {
        completionBar = completionBar.GetComponent<Image>();
    }

    void Update()
    {
        completionBar.fillAmount = Mathf.Lerp(0f, 1.0f, progress);
        //
        if (breadCheck.breadSlice.activeSelf)
        {
            if (counterAdding1)
            {
                counter += 1;
                counterAdding1 = false;
            }
        }
        if (knifeCheck.knifeButtered)
        {
            if (counterAdding2)
            {
                counter += 1;
                counterAdding2 = false;
            }
        }
        if (bread2Check.butterOn)
        {
            if (counterAdding3)
            {
                counter += 1;
                counterAdding3 = false;
            }
        }
        if (bread2Check.sprinklesOn)
        {
            if (counterAdding4)
            {
                counter += 1;
                counterAdding4 = false;
            }
        }
        //
        //
        //
        if (counter == 1)
        {
            counterAdded1 = true;
        }
        if (counter == 2)
        {
            counterAdded2 = true;
        }
        if (counter == 3)
        {
            counterAdded3 = true;
        }
        if (counter == 4)
        {
            counterAdded4 = true;
        }
        //
        //
        //
        if (counterAdded1)
        {
            if (progress < 0.25)
            {
                progress += Time.deltaTime / 1.5f;
            }
            else
            {
                counterAdded1 = false;
            }
        }
        if (counterAdded2)
        {
            if (progress < 0.5)
            {
                progress += Time.deltaTime / 1.5f;
            }
            else
            {
                counterAdded2 = false;
            }
        }
        if (counterAdded3)
        {
            if (progress < 0.75)
            {
                progress += Time.deltaTime / 1.5f;
            }
            else
            {
                counterAdded3 = false;
            }
        }
        if (counterAdded4)
        {
            if (progress < 1)
            {
                progress += Time.deltaTime / 1.5f;
            }
            else
            {
                counterAdded4 = false;
            }
        }
    }
}