using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathingUI : MonoBehaviour
{
    [SerializeField] private Box box;

    [SerializeField] private Image top;
    [SerializeField] private Image middle;
    [SerializeField] private Image eyes1;
    [SerializeField] private Image eyes2;
    [SerializeField] private Image eyes3;
    [SerializeField] private Image eyes4;
    [SerializeField] private Image eyes5;
    [SerializeField] private Image eyes6;
    [SerializeField] private Image eyes7;

    [SerializeField] private Animator eyeAnim;

    private void Start()
    {
        eyes2.color = new Color(255,255,255,0);
        eyes3.color = new Color(255, 255, 255, 0);
        eyes4.color = new Color(255, 255, 255, 0);
        eyes5.color = new Color(255, 255, 255, 0);
        eyes6.color = new Color(255, 255, 255, 0);
        eyes7.color = new Color(255, 255, 255, 0);
    }
    private void Update()
    {
        if (box.currentScore >= 200f)
        {
            StartCoroutine(FadeOut(0f, eyes6));
            StartCoroutine(FadeIn(1f, eyes7));
        }
        else if (box.currentScore >= 180f)
        {
            StartCoroutine(FadeOut(0f, eyes5));
            StartCoroutine(FadeIn(1f, eyes6));
            eyeAnim.speed = 0f;
        }
        else if (box.currentScore >= 160f)
        {
            StartCoroutine(FadeOut(0f, eyes4));
            StartCoroutine(FadeIn(1f, eyes5));
            eyeAnim.speed = 0.2f;
        }
        else if (box.currentScore >= 140f)
        {
            StartCoroutine(FadeOut(0f, eyes3));
            StartCoroutine(FadeIn(1f, eyes4));
            eyeAnim.speed = 0.4f;
        }
        else if(box.currentScore >= 120f)
        {
            StartCoroutine(FadeOut(0f, eyes2));
            StartCoroutine(FadeIn(1f, eyes3));
            eyeAnim.speed = 0.6f;
        }
        else if(box.currentScore >= 100f)
        {
            StartCoroutine(FadeOut(0f, eyes1));
            StartCoroutine(FadeIn(1f, eyes2));
            eyeAnim.speed = 0.8f;
        }
        else if(box.currentScore >= 80f)
            StartCoroutine(FadeOut(0f, middle));
        else if (box.currentScore >= 40f)
            StartCoroutine(FadeOut(0f, top));
    }

    IEnumerator FadeOut(float targetAlpha, Image image)
    {
        targetAlpha = 0f;
        Color curColor = image.color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, 2f * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
    }

    IEnumerator FadeIn(float targetAlpha, Image image)
    {
        targetAlpha = 1f;
        Color curColor = image.color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, 2f * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
    }
}
