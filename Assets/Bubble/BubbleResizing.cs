using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BubbleResizing : MonoBehaviour
{
    [Header ("Bubble")]
    SpriteRenderer bubble;
    ParticleSystem particle;
    Vector2 originalSize;
    Vector2 maxSizeVector;
    Vector3 sizeCalculated;
    public float maxSize;
    public float growSpeed;
    public float timeRemaining = 3.0f;
    public bool timerIsRunning = false;
    public float bubbleCooldown = 3.0f;
    public bool bubbleCooldownOn = false;
    [Header ("Gravity")]
    Rigidbody2D guyRigidbody;
    public float fallSpeedReduction;
    float gravity;
    public float minGravity;
    bool isKeyDown;
    private void Awake() 
    {
        bubble = this.GetComponent<SpriteRenderer>();
        guyRigidbody = this.transform.parent.GetComponent<Rigidbody2D>();
        gravity = guyRigidbody.gravityScale;
        particle = this.GetComponent<ParticleSystem>();
    }
    void Start()
    {
        originalSize = transform.localScale;
        maxSizeVector = originalSize*maxSize;
        timeRemaining = 3.0f;
    }

    public void Grow()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !bubbleCooldownOn)
        {
            isKeyDown = true;
            particle.Stop();
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isKeyDown = false;
            transform.localScale = originalSize; 
            timerIsRunning = false;
        }
        if (isKeyDown)
        {
            bubble.enabled = true;
            AdjustFallSpeed();
            if (transform.localScale.x < (maxSizeVector.x))
            {
                transform.localScale = transform.localScale*(1+(growSpeed/10)*Time.deltaTime);
                if(transform.localScale.x >= 0.02f)
                {
                    timerIsRunning = true;
                }
            }
        }
        else bubble.enabled = false;
    }
    public void AdjustFallSpeed()
    {
        if(guyRigidbody.gravityScale > minGravity)
        {
            guyRigidbody.gravityScale = guyRigidbody.gravityScale*(1-(fallSpeedReduction/10)*Time.deltaTime);
        }
    }
    void timerEnded()
    {
        Debug.Log("Timer Ends");
        particle.Play();
        timeRemaining = 3.0f;
        transform.localScale = originalSize;
        isKeyDown = false;
        bubbleCooldownOn = true;
    }

    void bubbleCooldownTimer()
    {
        Debug.Log("Bubble Cooldown Off");
        bubbleCooldown = 3.0f;
        bubbleCooldownOn = false;
    }
    void Update()
    {
        sizeCalculated = this.GetComponent<Renderer>().bounds.size;
        if(bubbleCooldownOn){
            if (bubbleCooldown > 0 )
            {
                bubbleCooldown -= Time.deltaTime;
            }
            else
            {
                bubbleCooldown = 0;
                bubbleCooldownOn = false;
            }
        }
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                timerEnded();
            }
        }
        else
        {
            timeRemaining = 3.0f;
        }
       Grow();
    }
}
