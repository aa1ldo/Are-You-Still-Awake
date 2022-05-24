using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KnifeUIscript : MonoBehaviour, IDragHandler
{
    public Sprite normalKnife;
    public Sprite butteredKnife;

    public bool knifeButtered;
    public bool knifeNormal = true;

    RectTransform rt;

    public void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rt.position = Input.mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == ("Butter"))
        {
            if (knifeNormal)
            {
                gameObject.GetComponent<Image>().sprite = butteredKnife;
                knifeNormal = false;
                knifeButtered = true;
            }
        }
    }
}
