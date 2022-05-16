using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanDesk : MonoBehaviour
{
    public Sprite tidyDesk;
    public bool deskCleaned;


    void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = tidyDesk;
        deskCleaned = true;
    }
}
