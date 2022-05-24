using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W5 : MonoBehaviour
{
    public bool pressed5;
    public void CleanWrapper5()
    {
        pressed5 = true;
    }

    private void Update()
    {
        if (pressed5)
        {
            Destroy(gameObject);
        }
    }
}
