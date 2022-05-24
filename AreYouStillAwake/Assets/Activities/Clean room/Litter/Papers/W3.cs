using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W3 : MonoBehaviour
{
    public bool pressed3;
    public void CleanWrapper3()
    {
        pressed3 = true;
    }

    private void Update()
    {
        if (pressed3)
        {
            Destroy(gameObject);
        }
    }
}
