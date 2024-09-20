using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float detectionRange = 5f;
    public float fieldOfViewAngle = 60f;
    public Transform player;
    public float detectionDelay = 1f;

    private void Update()
    {
        DetectPlayer();
    }

    private void DetectPlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;

        Vector3 facingDirection = transform.right;
        if (transform.localScale.x > 0)
        {
            facingDirection = -transform.right;
        }

        float angleToPlayer = Vector3.Angle(directionToPlayer, facingDirection);

        if (directionToPlayer.magnitude < detectionRange && angleToPlayer < fieldOfViewAngle / 2)
        {
            Invoke("OnPlayerDetected", detectionDelay);
        }
    }

    private void OnPlayerDetected()
    {
        Debug.Log("Player detected!!! You Lost!!");
        Time.timeScale = 0; 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Vector3 facingDirection = transform.right;
        if (transform.localScale.x > 0)
        {
            facingDirection = -transform.right;
        }

        Vector3 leftBoundary = Quaternion.Euler(0, 0, fieldOfViewAngle / 2) * facingDirection * detectionRange;
        Vector3 rightBoundary = Quaternion.Euler(0, 0, -fieldOfViewAngle / 2) * facingDirection * detectionRange;

        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}
