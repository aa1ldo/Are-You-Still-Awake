using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Biting : MonoBehaviour
{
    public Bread2UIscript breadScript;
    public GameObject breadEmpty;
    public BreadUIscript breadCheck;

    public Sprite bOne;
    public Sprite bTwo;
    public Sprite bThree;
    public Sprite bFour;
    public Sprite bFive;
    public Sprite bSix;

    public int biteCounter = 0;

    public void BreadBites()
    {
        if (breadScript.sprinklesOn)
        {
            biteCounter += 1;
        }
    }

    public void Update()
    {
        if(biteCounter == 1)
        {
            breadScript.gameObject.GetComponent<Image>().sprite = bOne;
            Destroy(breadScript.sprinkledBread);
            Destroy(breadScript.butteredBread);
        }
        if (biteCounter == 2)
        {
            breadScript.gameObject.GetComponent<Image>().sprite = bTwo;
        }
        if (biteCounter == 3)
        {
            breadScript.gameObject.GetComponent<Image>().sprite = bThree;
        }
        if (biteCounter == 4)
        {
            breadScript.gameObject.GetComponent<Image>().sprite = bFour;
        }
        if (biteCounter == 5)
        {
            breadScript.gameObject.GetComponent<Image>().sprite = bFive;
        }
        if (biteCounter == 6)
        {
            breadScript.gameObject.GetComponent<Image>().sprite = bSix;
        }
        if (biteCounter == 7)
        {
            breadCheck.dragging = false;
            breadEmpty.SetActive(false);
            GameManager.instance.completedSnackActivity = true;
        }
    }
}
