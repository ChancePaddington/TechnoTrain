using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 100f;
    [Range(0f, 50f)]
    [SerializeField] private float movementSpeed = 5f;
    [Range(0f, 50f)]
    [SerializeField] private float accelerationSpeed = 5f;
    [Range(0f, 50f)]
    [SerializeField] private float decelerationSpeed = 5f;

    public float currentSpeed;

    public GameObject beatChecker;

    private void Start()
    {
        currentSpeed = movementSpeed;
    }

    private void Update()
    {
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);  
    }

    //private void OnEnable()
    //{
    //    InputManager.OnTap += MoveOnBeat;
    //}

    //private void OnDisable()
    //{
    //    InputManager.OnTap -= MoveOnBeat;
    //}

    public void MoveOnBeat()
    {
        if (beatChecker.activeSelf)
        {
            currentSpeed += accelerationSpeed * Time.deltaTime;

        }
        else
        {
            currentSpeed -= decelerationSpeed * Time.deltaTime;
        }
    }

}
