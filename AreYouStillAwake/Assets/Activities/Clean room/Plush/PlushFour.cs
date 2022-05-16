using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlushFour : MonoBehaviour
{
    public CleanBed allowPlushie;
    public GameObject text;

    Vector3 plush4;

    public bool plushFour;

    void Start()
    {
        plush4 = new Vector3(-5.52f, 3.82f, -1f);

        text.SetActive(false);
    }

    void OnMouseDown()
    {
        if (allowPlushie.bedCleaned == false)
        {
            text.SetActive(true);
        }
        else if (allowPlushie.bedCleaned == true)
        {
            text.SetActive(false);
            if (gameObject.tag == "plushFour")
            {
                gameObject.transform.position = plush4;
                plushFour = true;
            }
        }
    }
}
