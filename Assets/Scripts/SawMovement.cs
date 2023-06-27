using UnityEngine;

public class SawMovement : MonoBehaviour
{   
    public Transform[] patrolPoints;
    public float moveSpeed = 5f;
    private int currentPointIndex = 0;

    private void Update()
    {        
        Vector3 direction = patrolPoints[currentPointIndex].position - transform.position;
        direction.Normalize();
        
        transform.position += direction * moveSpeed * Time.deltaTime;
        
        float distanceToTarget = Vector3.Distance(transform.position, patrolPoints[currentPointIndex].position);
        if (distanceToTarget < 0.1f)
        {            
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }
}