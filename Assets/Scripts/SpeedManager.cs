using UnityEditor.Rendering;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    [Range(0f, 20f)]
    [SerializeField] private float movementSpeed = 5f;
    private float maxSpeed = 100f;
    private float accelerationSpeed = 75f;

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

    private void OnEnable()
    {
        InputManager.OnTap += MoveOnBeat;
    }

    private void OnDisable()
    {
        InputManager.OnTap -= MoveOnBeat;
    }

    private void MoveOnBeat()
    {
        if (beatChecker.activeSelf)
        {
            currentSpeed += accelerationSpeed * Time.deltaTime;

        }
    }

}
