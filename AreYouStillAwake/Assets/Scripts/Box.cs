using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

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
    [SerializeField] private float incrementVal;
    [SerializeField] private float decreaseVal;
    public float maxScore = 200f;

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
            rb.AddForce(transform.up * thrust * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (currentScore >= maxScore)
        {
            currentScore = maxScore;
        }
        else if (collided && started)
        {
            if (currentScore < maxScore)
            {
                currentScore += incrementVal;
            }
        }
        else if (!collided && started)
        {
            if (currentScore > 0 && currentScore != maxScore)
            {
                currentScore -= decreaseVal;
            }
            else
            {
                currentScore = 0f;
            }
        }

        if (currentScore >= 80)
        {
            blossomAnim.SetBool("SecondThreshold", true);
        }
        
        if(currentScore >= 160)
        {
            blossomAnim.SetBool("ThirdThreshold", true);
        }
        
        if(currentScore >= 199)
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
