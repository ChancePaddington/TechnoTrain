using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public LapChange lapChange;
    private int lapScore;
    public TextMeshProUGUI lapScoreNumber;

    private void Start()
    {
        lapChange = GetComponent<LapChange>();
        lapScoreNumber.text = lapChange.currentLapScore;
    }

}
