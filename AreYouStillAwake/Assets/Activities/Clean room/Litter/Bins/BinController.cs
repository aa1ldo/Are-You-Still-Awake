using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BinController : MonoBehaviour
{
    public Sprite halfFull;
    public Sprite binFull;

    public DeskClean deskScript;
    public LitterController litterCheck;

    private void Update()
    {
        if (deskScript.cleanedDesk && !litterCheck.litterCleaned)
        {
            gameObject.GetComponent<Image>().sprite = halfFull;
        }
        else if (!deskScript.cleanedDesk && litterCheck.litterCleaned)
        {
            gameObject.GetComponent<Image>().sprite = halfFull;
        }


        if (deskScript.cleanedDesk && litterCheck.litterCleaned)
        {
            gameObject.GetComponent<Image>().sprite = binFull;
        }
    }
}
