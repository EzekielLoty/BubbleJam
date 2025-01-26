using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D rb;

    public float moveSpeed;
    public float jumpForce;
    private Vector2 _moveDirection;

    private bool isGrounded=true;
    private bool isKeyDown;

    
    private void Update()
    {
        Jump();
        Move();
    }

     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Move()
    {
        float horizontalInput = 0;

        // Check if the 'D' key or right arrow key is pressed
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1;
        }
        // Check if the left arrow key is pressed
        else if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1;
        }

        // Set the velocity based on the horizontal input and the current vertical velocity
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    public void Jump()
    {
        // Check if the 'UpArrow' or 'W' key is pressed for jumping
        if (isGrounded && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        {
            // Apply vertical force for the jump
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}




// using UnityEngine;
// using UnityEngine.InputSystem;
// public class Movement : MonoBehaviour
// {
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     public Rigidbody2D rb;

//     public float moveSpeed;

//     public float jumpForce;
//     private Vector2 _moveDirection;

//     private bool isGrounded;
//     private bool isKeyDown;
//     private void Update()
//     {
//         Jump();
//         Move();
//     }
//     void OnCollisionEnter2D(Collision2D col)
//     {
//         if (col.gameObject.tag == "Ground")
//         {
//             isGrounded = true;
//         }
//     }
//     void OnCollisionExit2D(Collision2D col)
//     {
//         if (col.gameObject.tag == "Ground")
//         {
//             isGrounded = false;
//         }
//     }

//     void Start()
//     {
//     }


//     // public void OnMove(InputAction.CallbackContext context)
//     // {
//     //     rb.linearVelocity =new Vector2 (context.ReadValue<Vector2>().x*moveSpeed, rb.linearVelocity.y);
//     // }

//     public void Move()
//     {
//         float horizontalInput = 0;

//         // Check if the 'D' key or right arrow key is pressed
//         if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
//         {
//             horizontalInput = 1;
//         }
//         // Check if the left arrow key is pressed
//         else if (Input.GetKey(KeyCode.LeftArrow))
//         {
//             horizontalInput = -1;
//         }

//         // Set the velocity based on the horizontal input and the current vertical velocity
//         rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
//     }

//     // public void OnJump(InputAction.CallbackContext context)
//     // {
//     //     if (context.performed && isGrounded) // Check if jump is triggered and the player is grounded
//     //     {
//     //         rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Apply a vertical force for the jump
//     //     }
//     // }

//     // public void Jump(){
//     //     if(Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W))
//     //     {
//     //         isKeyDown = true;
//     //     }
//     //     if(Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W))
//     //     {
//     //         isKeyDown = false;
//     //     }
//     //     if (isKeyDown && isGrounded){
//     //         Debug.Log("!");
//     //         rb.linearVelocity = new Vector2(rb.linearVelocity.y, jumpForce);
//     //     }
//     // }



    
//     private void FixedUpdate()
//     {
//         //rb.linearVelocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
//     }
// }
