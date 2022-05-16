using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapperTwo : MonoBehaviour
{
    Vector3 cleanWrapper2;
    public bool wrapper2;

    void Start()
    {;
        cleanWrapper2 = new Vector3(1.622f, 3.982f, -2);
    }

    void OnMouseDown()
    {
        if (gameObject.tag == "WrapperTwo")
        {
            gameObject.transform.position = cleanWrapper2;
            wrapper2 = true;
        }
    }
}
