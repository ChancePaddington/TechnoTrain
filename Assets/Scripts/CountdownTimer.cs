using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public UnityEvent onTimerEnd;
    private float timeRemaining;
    private bool isRunning;

    public float duration = 300f;
    public bool startOnAwake = true;
    public bool loop = false;

    public GameObject endScreen;

    public Animator timerWarning;

    //public TextMeshProUGUI endTime;

    //Audio
    [SerializeField] AudioClip alarmSound;
    [UnityEngine.Range(1, 10)]
    [SerializeField] float volume = 1f;

    private void Awake()
    {
        if (startOnAwake)
        {
            StartTimer();
        }
    }

    private void Update()
    {
        if (!isRunning) return;

        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            isRunning = false;
            endScreen.SetActive(true);
            onTimerEnd?.Invoke();

            if (loop)
                StartTimer();

        }

        UpdateTimerDisplay();

        if (timeRemaining < 30f)
        {
            timerWarning.SetBool("timerFlash", true);
        }
        else
        {
            timerWarning.SetBool("timerFlash", false);
        }

        if (timeRemaining == 20f)
        {
            SoundManager.instance.PlaySoundFXClip(alarmSound, transform, volume);
        }

        //endTime.text = "Time Remaining: " + ((int)timeRemaining * 10).ToString();

    }

    public void StartTimer()
    {
        timeRemaining = duration;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer(float newDuration)
    {
        duration = newDuration;
        StartTimer();
    }

    public void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            timerText.text = $"{minutes:00} : {seconds:00}";
        }
    }

    public float GetTimeRemaining() => timeRemaining;
    public bool IsRunning() => isRunning;
}
