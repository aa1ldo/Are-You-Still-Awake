using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseParent : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    public void Exit()
    {
        player.freezePlayer = false;

        transform.root.gameObject.SetActive(false);
    }
}
