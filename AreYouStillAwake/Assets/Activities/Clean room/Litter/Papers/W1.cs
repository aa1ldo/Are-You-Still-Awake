using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class W1 : MonoBehaviour
{
    public bool pressed1;
    public void CleanWrapper1()
    {
        pressed1 = true;
    }

    private void Update()
    {
        if (pressed1)
        {
            Destroy(gameObject);
        }
    }
}
