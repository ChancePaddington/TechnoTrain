using UnityEngine;

public class Junction : MonoBehaviour
{
    private SpeedManager speedManager;

    [SerializeField] private float speedLimit;

    private void Start()
    {
        speedManager = FindAnyObjectByType<SpeedManager>();
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
