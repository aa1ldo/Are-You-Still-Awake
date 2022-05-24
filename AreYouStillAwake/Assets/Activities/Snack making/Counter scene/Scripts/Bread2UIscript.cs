using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script for the image changing of the bread
public class Bread2UIscript : MonoBehaviour
{
    public KnifeUIscript knifeScript;
    public Text errorMsg;

    public bool butterOn;
    public bool sprinklesOn;

    public GameObject butteredBread;
    public GameObject sprinkledBread;

    private void Start()
    {
        errorMsg.enabled = false;

        butteredBread.SetActive(false);
        sprinkledBread.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == ("Knife"))
        {
            if (knifeScript.knifeButtered)
            {
                butteredBread.SetActive(true);
                knifeScript.gameObject.GetComponent<Image>().sprite = knifeScript.normalKnife;
                knifeScript.knifeNormal = true;
                knifeScript.knifeButtered = false;
                butterOn = true;
                if (errorMsg.enabled)
                {
                    errorMsg.enabled = false;
                }
            }
        }
        if(collision.gameObject.name == ("Sprinkle jar"))
        {
            if (butterOn)
            {
                sprinkledBread.SetActive(true);
                sprinklesOn = true;
            }
            else
            {
                errorMsg.enabled = true;
            }
        }
    }
}
