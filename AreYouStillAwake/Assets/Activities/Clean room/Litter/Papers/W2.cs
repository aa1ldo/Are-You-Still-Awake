using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W2 : MonoBehaviour
{
    public bool pressed2;
    public void CleanWrapper2()
    {
        pressed2 = true;
    }

    private void Update()
    {
        if (pressed2)
        {
            Destroy(gameObject);
        }
    }
}
