using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour
{
    [SerializeField] private GameObject toExpand;

    [SerializeField] private GameObject leftButtons;
    [SerializeField] private GameObject rightButtons;

    public void ExpandTrigger()
    {
        toExpand.SetActive(true);
        leftButtons.SetActive(false);
        rightButtons.SetActive(false);
    }
}
