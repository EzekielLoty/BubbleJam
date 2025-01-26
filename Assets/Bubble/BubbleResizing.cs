using UnityEngine;
public class BubbleResizing : MonoBehaviour
{
    [Header ("Bubble")]
    SpriteRenderer bubble;
    Vector2 originalSize;
    Vector2 maxSizeVector;
    public float maxSize;
    public float growSpeed;

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
    }
    void Start()
    {
        originalSize = transform.localScale;
        maxSizeVector = originalSize*maxSize;
    }

    public void Grow()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isKeyDown = true;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isKeyDown = false;
        }
        if (isKeyDown)
        {
            Debug.Log("!");
            bubble.enabled = true;
            AdjustFallSpeed();
            if (transform.localScale.x < (maxSizeVector.x))
            {
                transform.localScale = transform.localScale*(1+(growSpeed/10)*Time.deltaTime);
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
    void Update()
    {
       Grow();
    }
}
