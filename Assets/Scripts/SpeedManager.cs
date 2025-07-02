using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] public int maxSpeed = 50;
    [Range(0f, 50f)]
    [SerializeField] private int movementSpeed = 4;
    [Range(0f, 50f)]
    [SerializeField] private int accelerationSpeed = 1;
    [Range(0f, 50f)]
    [SerializeField] public int decelerationSpeed = 5;

    //Audio
    public SoundLoopManager soundLoopManager;
    [SerializeField] AudioClip railSound;
    [Range(1, 10)]
    [SerializeField] float volume = 1f;

    //Train goes off camera when too fast, speed modifier?

    public TextMeshProUGUI speedometer;
    public float currentSpeed;
    public GameObject beatChecker;
    public int gameOver;

    private void Start()
    {
        currentSpeed = movementSpeed;
        SoundManager.instance.PlayLoopFXSound(railSound, transform, volume);
    }

    private void Update()
    {
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        speedometer.text = currentSpeed + "Mph";
    }

    public void MoveOnBeat()
    {
        //Checking if gameobject beat checker is active at time of input
        if (beatChecker.activeSelf)
        {
            currentSpeed += accelerationSpeed;

        }
        else
        {
            Deceleration();
        }
    }

    public void Deceleration()
    {
        currentSpeed -= decelerationSpeed;
    }

    private void OnDisable()
    {
        soundLoopManager.Stop();
        TransitionToGameOverScene();
    }

    public void TransitionToGameOverScene()
    {
        SceneController.LoadScene(gameOver);

    }

}
