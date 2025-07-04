using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CountdownTimer : MonoBehaviour
{
    public float duration = 60f;
    public bool startOnAwake = true;
    public bool loop = false;

    public TextMeshProUGUI timerText;
    public UnityEvent onTimerEnd;
    private float timeRemaining;
    private bool isRunning;

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
            onTimerEnd?.Invoke();

            if (loop)
                StartTimer(); 
            
        }

        UpdateTimerDisplay();
        
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

    public void ResetTimer (float newDuration)
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
