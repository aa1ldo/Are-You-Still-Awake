using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlushOne : MonoBehaviour
{
    public PlushTwo p2;
    public PlushThree p3;
    public PlushFour p4;


    public CleanBed allowPlushie;
    public GameObject text;

    Vector3 plush1;

    bool plushOne;
    public bool plushCleaned;

    void Start()
    {
        plush1 = new Vector3(-7.17f, 3.7f, -1f);

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
            if (gameObject.tag == "plushOne")
            {
                gameObject.transform.position = plush1;
                plushOne = true;
            }
        }
    }

    void Update()
    {
        if (plushOne && p2.plushTwo && p3.plushThree && p4.plushFour)
        {
            plushCleaned = true;
        }
    }
}

