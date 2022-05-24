using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBooks : MonoBehaviour
{
    public bool blueCleaned;
    public void cleanBlue()
    {
        Destroy(gameObject);
        blueCleaned = true;
    }
}
