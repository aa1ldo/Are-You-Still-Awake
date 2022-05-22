using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteActivity : MonoBehaviour
{
    public void RoomActivityFinished()
    {
        GameManager.instance.completedRoomActivity = true;
    }

    public void SnackActivityFinished()
    {
        GameManager.instance.completedSnackActivity = true;
    }
}
