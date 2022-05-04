using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathingProgress : MonoBehaviour
{
    Slider slider;

    [SerializeField] private Box box;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        slider.value = box.currentScore;
    }
}
