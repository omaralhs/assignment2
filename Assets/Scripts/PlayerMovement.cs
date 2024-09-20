using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public Animator animator;
    public float moveSpeed = 5f;
    public float jumpForce = 10f; 
    public Rigidbody2D rb;
    private Vector2 movement;
    private bool isFacingRight = true;
    private bool isGrounded; 
    public Transform groundCheck; 
    public float groundCheckRadius = 0.2f; 
    public LayerMask groundLayer; 

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(movement.x)); 

        if (movement.x < 0 && !isFacingRight)
        {
            Flip();
        }
        else if (movement.x > 0 && isFacingRight)
        {
            Flip();
        }

       
    }

    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; 
        transform.localScale = scale;
    }
}
