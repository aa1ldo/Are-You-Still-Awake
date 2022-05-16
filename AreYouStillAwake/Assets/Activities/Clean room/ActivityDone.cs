using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivityDone : MonoBehaviour
{
    public CleanBed bed;
    public CleanClothes clothes;
    public CleanDesk desk;
    public WrapperOne litter;
    public PlushOne plush;

    // Update is called once per frame
    void Update()
    {
        if(bed.bedCleaned && clothes.clothesCleaned && desk.deskCleaned && litter.wrappersCleaned && plush.plushCleaned)
        {
            SceneManager.UnloadSceneAsync("RoomCleaning");
        }
    }
}
