using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlushTwo : MonoBehaviour
{
    public CleanBed allowPlushie;
    public GameObject text;

    Vector3 plush2;

    public bool plushTwo;

    void Start()
    {
        plush2 = new Vector3(-6.6f, 3.75f, -1f);

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
            if (gameObject.tag == "plushTwo")
            {
                gameObject.transform.position = plush2;
                plushTwo = true;
            }
        }
    }
}
