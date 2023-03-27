using UnityEngine;

public class Boss1Controller : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 2f;

    private int waypoint = 0;

    private void Update()
    {
        Move();
    }
    
    // Method that makes the enemy move
    private void Move()
    {

        // If enemy reached the last waypoint then it stops
        if (waypoint <= waypoints.Length - 1)
        {

            // Move Enemy from current waypoint to the next one
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypoint].transform.position,
               moveSpeed * Time.deltaTime);

            // When enemy moves to the next waypoint, add 1 to the waypoint index
            if (transform.position.x == waypoints[waypoint].transform.position.x &&
                transform.position.y == waypoints[waypoint].transform.position.y)
            {
                waypoint += 1;
            }
        }
    }
}