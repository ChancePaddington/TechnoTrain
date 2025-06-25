using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] private int maxSpeed = 100;
    [Range(0f, 50f)]
    [SerializeField] private int movementSpeed = 4;
    [Range(0f, 50f)]
    [SerializeField] private int accelerationSpeed = 2;
    [Range(0f, 50f)]
    [SerializeField] private int decelerationSpeed = 2;

    public TextMeshProUGUI speedometer;
    public float currentSpeed;
    public GameObject beatChecker;

    private void Start()
    {
        currentSpeed = movementSpeed;
        //Update text component with the currentSpeed float value
        speedometer.text = currentSpeed + "Mph";
    }

    private void Update()
    {
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);  
    }

    public void MoveOnBeat()
    {
        //Checking if gameobject beat checker is active at time of input
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
