using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LitterController : MonoBehaviour
{
    public bool litterCleaned;

    public W1 w1;
    public W2 w2;
    public W3 w3;
    public W4 w4;
    public W5 w5;

    void Update()
    {

        if(w1.pressed1 && w2.pressed2 && w3.pressed3 && w4.pressed4 && w5.pressed5)
        {
            litterCleaned = true;
        }
    }
}
