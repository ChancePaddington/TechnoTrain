using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class FollowLine : MonoBehaviour
{
    private Rigidbody2D rb;
    public SpeedManager speedManager;
    public ProceduralManager proceduralManager;
    public Transform playerTarget;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speedManager.currentSpeed;

        proceduralManager.currentLineArray = proceduralManager.redWaypoints;

        //Set the position of the player target to the first waypoint
        playerTarget.position = proceduralManager.currentLineArray[0].position;

        Vector3 direction = proceduralManager.currentLineArray[proceduralManager.currentWaypointIndex].transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speedManager.currentSpeed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

    }

    public void MoveToTarget()
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
        Vector3 direction = proceduralManager.currentLineArray[proceduralManager.currentWaypointIndex].transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speedManager.currentSpeed;
    }

    //Based on distance to target, switch to next waypoint when current waypoint is reached
    private void SwitchWaypointTarget()
    {
        proceduralManager.currentWaypointIndex = proceduralManager.currentWaypointIndex + 1;
        playerTarget.position = proceduralManager.currentLineArray[proceduralManager.currentWaypointIndex].position;
    }

    public void SwitchToGreenLine()
    {
        //If at junction waypoint
        if (proceduralManager.currentWaypointIndex == 1)
        {
            //Changes current array variable to indicated array
            proceduralManager.currentLineArray = proceduralManager.greenWaypoints;
        }
    }

    public void SwitchToPurpleLine()
    {
        if (proceduralManager.currentWaypointIndex == 1)
        {
            proceduralManager.currentLineArray =   proceduralManager.purpleWaypoints;
        }
    }

    public void SwitchToRedLine()
    {
        if (proceduralManager.currentWaypointIndex == 1)
        {
            proceduralManager.currentLineArray = proceduralManager.redWaypoints;
        }
    }
}
