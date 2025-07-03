using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] public float maxSpeed = 100f;
    [Range(0f, 50f)]
    [SerializeField] private float movementSpeed = 4f;
    [Range(0f, 50f)]
    [SerializeField] private float accelerationSpeed = 50f;
    [Range(0f, 50f)]
    [SerializeField] public float decelerationSpeed = 1f;

    //Audio
    public SoundLoopManager soundLoopManager;
    [SerializeField] AudioClip railSound;
    [SerializeField] AudioClip decelerationSound;   
    [Range(1, 10)]
    [SerializeField] float volume = 1f;

    //Train goes off camera when too fast, speed modifier?

    public TextMeshProUGUI speedometer;
    public float currentSpeed;
    public GameObject beatChecker;

    private void Start()
    {
        currentSpeed = movementSpeed;
        SoundManager.instance.PlayLoopFXSound(railSound, transform, volume);
    }

    private void Update()
    {
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        currentSpeed += accelerationSpeed * Time.deltaTime;
        speedometer.text = ((int)currentSpeed).ToString() + "Mph";
    }

    public void Deceleration()
    {
        currentSpeed -= decelerationSpeed;
        SoundManager.instance.PlaySoundFXClip(decelerationSound, transform, volume);
    }

}
