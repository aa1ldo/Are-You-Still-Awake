using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Rigidbody2D rb;

    bool started = false;
    bool onscreen = false;
    public float currentScore;
    bool collided = false;
    bool locked = false;
    float yPos;

    [SerializeField] private GameObject blossom;
    [SerializeField] Animator boxAnim;
    [SerializeField] Animator blossomAnim;
    [SerializeField] private float thrust;
    [SerializeField] private float scoreValue;
    [SerializeField] private float maxScore = 100f;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        started = false;
        onscreen = false;
        collided = false;
        locked = false;
        currentScore = 0f;

        gameObject.SetActive(true);
    }
    private void Update()
    {
        if (!started)
        {
            rb.Sleep();
        }

        if(blossom.transform.position.y > 0 && !onscreen)
        {
            boxAnim.SetBool("FadeIn", true);
            onscreen = true;
        }

        if (Input.GetKeyDown(KeyCode.Z) && !started && onscreen)
        {
            rb.WakeUp();
            started = true;
            blossomAnim.SetBool("FirstThreshold", true);
        }
        else if(Input.GetKey(KeyCode.Z) && started)
        {
            rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
        }

        if (currentScore >= 100)
        {
            currentScore = 100;
        }
        else if (collided && started)
        {
            if (currentScore < maxScore)
            {
                currentScore += scoreValue;
            }
        }
        else if (!collided && started)
        {
            if (currentScore > 0 && currentScore != maxScore)
            {
                currentScore -= scoreValue;
            }
            else
            {
                currentScore = 0f;
            }
        }

        if (currentScore >= 40)
        {
            blossomAnim.SetBool("SecondThreshold", true);
        }
        
        if(currentScore >= 80)
        {
            blossomAnim.SetBool("ThirdThreshold", true);
        }
        
        if(currentScore >= 99)
        {
            if (!locked)
            {
                yPos = transform.position.y;
                locked = true;
            }

            blossomAnim.SetBool("FourthThreshold", true);
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
            boxAnim.SetBool("FadeOut", true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Blossom")
        {
            collided = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Blossom")
        {
            collided = false;
        }
    }
}
