using UnityEngine;

public class BubbleResizing : MonoBehaviour
{
    public Vector3 targetSize = new Vector3(2, 2, 2); // Target size when resizing
    public Vector3 maxSize = new Vector3(3, 3, 3);    // Maximum allowed size
    public float resizeSpeed = 2f;                   // Speed of resizing
    public float resizeThreshold = 0.01f;           // Threshold to stop resizing

    private Vector3 originalSize;                   // Original size of the GameObject
    private bool isResizing = false;                // Is resizing in progress
    private bool isExpanding = true;                // Expanding or shrinking

    void Start()
    {
        // Store the original size of the GameObject
        originalSize = transform.localScale;

        // Ensure the target size does not exceed the max size
        targetSize = Vector3.Min(targetSize, maxSize);
    }

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isResizing = true;                      // Start resizing
            isExpanding = !isExpanding;            // Toggle between expanding and shrinking
        }

        // Perform resizing
        if (isResizing)
        {
            Vector3 target = isExpanding ? targetSize : originalSize; // Determine target size

            // Smoothly resize the object
            transform.localScale = Vector3.Lerp(transform.localScale, target, Time.deltaTime * resizeSpeed);

            // Check if the size is close enough to the target size
            if (Vector3.Distance(transform.localScale, target) < resizeThreshold)
            {
                transform.localScale = target;      // Snap to the target size
                isResizing = false;                // Stop resizing
            }
        }

        // Enforce the maximum size cap
        if (transform.localScale.x > maxSize.x || transform.localScale.y > maxSize.y || transform.localScale.z > maxSize.z)
        {
            transform.localScale = maxSize; // Clamp to the maximum size
            isResizing = false;             // Stop resizing if it exceeds the cap
        }
    }
}
