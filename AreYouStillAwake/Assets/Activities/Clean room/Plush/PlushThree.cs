using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlushThree : MonoBehaviour
{
    public CleanBed allowPlushie;
    public GameObject text;

    Vector3 plush3;

    public bool plushThree;

    void Start()
    {
        plush3 = new Vector3(-6.08f, 3.75f, -1f);

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
            if (gameObject.tag == "plushThree")
            {
                gameObject.transform.position = plush3;
                plushThree = true;
            }
        }
    }
}
