using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanBed : MonoBehaviour
{
    public Sprite tidyBed;
    public bool bedCleaned = false;


    void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = tidyBed;
        bedCleaned = true;
    }
}
