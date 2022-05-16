using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapperThree : MonoBehaviour
{
    Vector3 cleanWrapper3;
    public bool wrapper3;

    void Start()
    {
        cleanWrapper3 = new Vector3(1.838f, 4.124f, -2);
    }

    void OnMouseDown()
    {
        if (gameObject.tag == "WrapperThree")
        {
            gameObject.transform.position = cleanWrapper3;
            wrapper3 = true;
        }
    }
}
