using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanClothes : MonoBehaviour
{
    Vector2 cleanPosition;
    public bool clothesCleaned = false;
    void Start()
    {
        cleanPosition = new Vector2(-2.73f, 3.41f);
    }
    void OnMouseDown()
    {
        gameObject.transform.position = cleanPosition;
        clothesCleaned = true;
    }
}
