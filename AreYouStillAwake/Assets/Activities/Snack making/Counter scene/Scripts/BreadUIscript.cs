using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//script for the dragging of the bread

public class BreadUIscript : MonoBehaviour, IDragHandler
{
    public GameObject breadSlice;
    RectTransform rt;
    public bool dragging;

    public Sprite minusBread;
    public GameObject breadLoaf;

    public void Start()
    {
        rt = breadSlice.GetComponent<RectTransform>();
        breadSlice.SetActive(false);
    }

    public void loafClicked()
    {
        dragging = true;
        breadLoaf.GetComponent<Image>().sprite = minusBread;
    }

    public void Update()
    {
        if (dragging)
        {
            breadSlice.SetActive(true);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (breadSlice.activeSelf)
        {
            rt.position = Input.mousePosition;
        }
    }
}
