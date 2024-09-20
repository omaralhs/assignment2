using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; 
    public Animator animator; 
    private Vector3 startingPosition;
    private bool isFacingRight = false; 

    private void Start()
    {
        startingPosition = transform.position; 
        StartCoroutine(MoveBackAndForth()); 
    }

    private IEnumerator MoveBackAndForth()
    {
        while (true) 
        {
            yield return MoveEnemy(Vector3.right, 3f); 
            yield return new WaitForSeconds(3f); 
            yield return MoveEnemy(Vector3.left, 3f); 
            yield return new WaitForSeconds(3f); 
        }
    }

    private IEnumerator MoveEnemy(Vector3 direction, float distance)
    {
        animator.SetBool("isWalking", true); 
        float targetPosition = transform.position.x + (direction.x * distance);

        while ((direction == Vector3.right && transform.position.x < targetPosition) ||
               (direction == Vector3.left && transform.position.x > targetPosition))
        {
            transform.position += direction * moveSpeed * Time.deltaTime;

           
            if (direction == Vector3.right && !isFacingRight)
            {
                Flip();
            }
            else if (direction == Vector3.left && isFacingRight)
            {
                Flip();
            }

            yield return null; 
        }

        animator.SetBool("isWalking", false); 
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; 
        transform.localScale = scale;
    }

    private void OnDisable()
    {
        animator.SetBool("isWalking", false); 
    }
}
