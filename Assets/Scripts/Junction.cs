using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Junction : MonoBehaviour
{
    private SpeedManager speedManager;
    [SerializeField] private Transform reset;

    [SerializeField] private int speedLimit;
    public TextMeshProUGUI speedLimitSign;

    public ParticleSystem ps;

    private void Start()
    {
        speedManager = FindAnyObjectByType<SpeedManager>();
        ps = GetComponentInChildren<ParticleSystem>();
        speedLimitSign.text = speedLimit + "Mph";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Create variable to check players speed on collision
            Debug.Log("Train touched");
            float playerSpeed = speedManager.currentSpeed;

            //If less than set speed limit
            if (playerSpeed < speedLimit)
            {
                Debug.Log("Collidercollidin");
                collision.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Play Particles");
                ps.Play();
            }
        }
    }

}
