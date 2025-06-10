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

    public void Update()
    {
        MoveToTarget();

        if (Input.GetKeyDown(KeyCode.W))
        {
            SwitchToGreenLine();
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            SwitchToPurpleLine();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            SwitchToRedLine();
        }
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
        Vector3 direction = currentLineArray[currentWaypointIndex].transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speedManager.currentSpeed;
    }

    //Based on distance to target, switch to next waypoint when current waypoint is reached
    private void SwitchWaypointTarget()
    {
        currentWaypointIndex = currentWaypointIndex + 1;
        playerTarget.position = currentLineArray[currentWaypointIndex].position;
    }

    private void SwitchToGreenLine()
    {
        //If at junction waypoint
        if (currentWaypointIndex == 1)
        {
            //Changes current array variable to indicated array
            currentLineArray = greenWaypoints;
        }
    }

    private void SwitchToPurpleLine()
    {
        if (currentWaypointIndex == 1)
        {
            currentLineArray = purpleWaypoints;
        }
    }

    private void SwitchToRedLine()
    {
        if (currentWaypointIndex == 1)
        {
            currentLineArray = redWaypoints;
        }
    }
}
