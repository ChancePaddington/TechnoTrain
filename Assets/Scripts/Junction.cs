using UnityEngine;
using UnityEngine.UI;

public class Junction : MonoBehaviour
{
    private SpeedManager speedManager;

    [SerializeField] private int speedLimit;
    //public Text speedLimitSign;

    private void Start()
    {
        speedManager = FindAnyObjectByType<SpeedManager>();
        //speedLimitSign.text = "Threshold" + speedLimit;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Create variable to check players speed on collision
            Debug.Log("Train touched");
            float playerSpeed = speedManager.currentSpeed;
            //bool underSpeedLimit = playerSpeed < speedLimit;

            //If less than set speed limit
            if (playerSpeed < speedLimit)
            {
                Debug.Log("Collidercollidin");
                collision.gameObject.SetActive(false);
            }
        }
    }
}
