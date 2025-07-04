using UnityEngine;


public class FollowLine : MonoBehaviour
{
   
    private Rigidbody2D rb;
    public SpeedManager speedManager;
    private SpriteRenderer sprite;
    //public LineRenderer lineRenderer;

    //Line waypoint variables
    public Transform playerTarget;
    public Transform[] redWaypoints;
    public Transform[] greenWaypoints;
    public Transform[] purpleWaypoints;
    public Transform[] currentLineArray;
    public LineColourEnum.LineColour lineColour;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        //lineRenderer = rb.GetComponent<LineRenderer>();
        rb.linearVelocity = transform.up * speedManager.currentSpeed;

        currentLineArray = redWaypoints;
        lineColour = LineColourEnum.LineColour.red;

        //Set the position of the player target to the first waypoint
        playerTarget.position = currentLineArray[0].position;

        Vector3 direction = currentLineArray[currentWaypointIndex].transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speedManager.currentSpeed * Time.deltaTime;

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

        //Rotate sprite to current waypoint position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
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
        if (currentLineArray[currentWaypointIndex].CompareTag("Junction"))
        {
            //Changes current array variable to indicated array
            currentLineArray = greenWaypoints;
            lineColour = LineColourEnum.LineColour.green;
        }
    }

    public void SwitchToPurpleLine()
    {
        if (currentLineArray[currentWaypointIndex].CompareTag("Junction"))
        {
            currentLineArray = purpleWaypoints;
            lineColour = LineColourEnum.LineColour.purple;
        }
    }

    public void SwitchToRedLine()
    {
        if (currentLineArray[currentWaypointIndex].CompareTag("Junction"))
        {
            currentLineArray = redWaypoints;
            lineColour = LineColourEnum.LineColour.red;
        }
    }


    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
