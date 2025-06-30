using UnityEngine;

public class FollowLine : MonoBehaviour
{
    private Rigidbody2D rb;
    public SpeedManager speedManager;

    //Line waypoint variables
    public Transform playerTarget;
    public Transform[] redWaypoints;
    public Transform[] greenWaypoints;
    public Transform[] purpleWaypoints;
    public Transform[] currentLineArray;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speedManager.currentSpeed;

        currentLineArray = redWaypoints;

        //Set the position of the player target to the first waypoint
        playerTarget.position = currentLineArray[0].position;

        Vector3 direction = currentLineArray[currentWaypointIndex].transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speedManager.currentSpeed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        //Calculating distance between Player and Player Target
        float distanceToTarget = Vector3.Distance(transform.position, playerTarget.position);
        //When distancetotarget is inferior to 0.5f , we are at target
        bool isAtTarget = distanceToTarget < 0.5f;

        if (isAtTarget)
        {
            SwitchWaypointTarget();
        }

        rb.linearVelocity = transform.up * speedManager.currentSpeed;
        Vector3 direction = currentLineArray[currentWaypointIndex].transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speedManager.currentSpeed;
    }

    //Based on distance to target, switch to next waypoint when current waypoint is reached
    private void SwitchWaypointTarget()
    {
        currentWaypointIndex = currentWaypointIndex + 1;

        bool indexIsOutOfRange = currentWaypointIndex == currentLineArray.Length;
        if(indexIsOutOfRange)
        {
            currentWaypointIndex = 0;
        }

        playerTarget.position = currentLineArray[currentWaypointIndex].position;
    }

    public void SwitchToGreenLine()
    {
        //If at junction waypoint
        if (currentWaypointIndex is 1 or 3 or 6 or 8 or 9)
        {
            //Changes current array variable to indicated array
            currentLineArray = greenWaypoints;
        }
    }

    public void SwitchToPurpleLine()
    {
        if (currentWaypointIndex is 1 or 3 or 6 or 8 or 9)
        {
            currentLineArray = purpleWaypoints;
        }
    }

    public void SwitchToRedLine()
    {
        if (currentWaypointIndex is 1 or 3 or 6 or 8 or 9)
        {
            currentLineArray = redWaypoints;
        }
    }
}
