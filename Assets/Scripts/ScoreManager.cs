using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int lapScore = 0;
    public int lapHighScore;
    public TextMeshProUGUI lapScoreNumber;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UpdateLapScoreDisplay();
    }

    void AddScore(int amount)
    {
        lapScore += amount;
        UpdateLapScoreDisplay();
    }

    public int GetScore()
    {
        return lapScore;
    }

    void UpdateLapScoreDisplay()
    {
        if (lapScoreNumber != null)
        {
            lapScoreNumber.text = "Laps Lasted: " + lapScore.ToString();
        }

    }

}
