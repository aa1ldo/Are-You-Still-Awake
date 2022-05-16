using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed;
    [SerializeField] private float maxSpeed = 5f;
    public bool freezePlayer;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Animator animator;

    private static GameObject instance;

    Vector2 movement;

    void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        moveSpeed = maxSpeed;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (freezePlayer)
        {
            moveSpeed = 0f;
        }
        else
        {
            moveSpeed = maxSpeed;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
