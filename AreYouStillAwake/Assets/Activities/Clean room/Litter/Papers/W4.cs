using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W4 : MonoBehaviour
{
    public bool pressed4;
    public void CleanWrapper4()
    {
        pressed4 = true;
    }

    private void Update()
    {
        if (pressed4)
        {
            Destroy(gameObject);
        }
    }
}
