using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseExpanded : MonoBehaviour
{
    [SerializeField] private GameObject toClose;

    [SerializeField] private GameObject leftButtons;
    [SerializeField] private GameObject rightButtons;

    public void CloseTrigger()
    {
        toClose.SetActive(false);
        leftButtons.SetActive(true);
        rightButtons.SetActive(true);
    }
}
