using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeskClean : MonoBehaviour
{
    public Sprite cleanVer;
    public bool cleanedDesk;

    public GameObject pile1;
    public GameObject pile2;
    public void cleanDesk()
    {
        gameObject.GetComponent<Image>().sprite = cleanVer;
        Destroy(pile1);
        Destroy(pile2);
        //Change above script to access the sourceimage instead of sprite, lesson ended before i could.
        cleanedDesk = true;
    }
}
