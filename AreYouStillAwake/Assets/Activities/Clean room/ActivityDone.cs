using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivityDone : MonoBehaviour
{
    //public BedClean bed;
    public DeskClean desk;
    public LitterController litter;
    //public PlushController plush;

    // Update is called once per frame
    void Update()
    {
        if(/*bed.bedCleaned &&*/ desk.cleanedDesk && litter.litterCleaned /*&& plush.plushCleaned*/)
        {
            GameManager.instance.completedRoomActivity = true;
        }
    }
}
