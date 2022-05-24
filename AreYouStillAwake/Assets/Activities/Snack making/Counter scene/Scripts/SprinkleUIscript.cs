using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SprinkleUIscript : MonoBehaviour, IDragHandler
{
    RectTransform rt;
    bool pickingUp;

    public void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rt.position = Input.mousePosition;
    }
}
