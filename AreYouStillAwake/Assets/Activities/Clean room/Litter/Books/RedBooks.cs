using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBooks : MonoBehaviour
{
    public bool redCleaned;
    public void cleanRed()
    {
        Destroy(gameObject);
        redCleaned = true;
    }
}
