using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapperOne : MonoBehaviour
{
    public WrapperTwo w2;
    public WrapperThree w3;

    Vector3 cleanWrapper;

    public bool wrappersCleaned;
    bool wrapper1;

    void Start()
    {
        cleanWrapper = new Vector3(1.826f, 3.815f, -2);
    }

    void OnMouseDown()
    {
        if (gameObject.tag == "WrapperOne")
        {
            gameObject.transform.position = cleanWrapper;
            wrapper1 = true;
        }
    }

    void Update()
    {
        if (wrapper1 && w2.wrapper2 && w3.wrapper3)
        {
            wrappersCleaned = true;
        }
    }
}
