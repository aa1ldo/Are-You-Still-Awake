using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private GameObject destination;

    Vector2 destinationPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            destinationPos = new Vector2(collision.transform.position.x, destination.transform.position.y);
            collision.transform.position = destinationPos;
        }
    }
}
