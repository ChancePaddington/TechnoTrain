using UnityEngine;

public class LinePoints : MonoBehaviour
{
    [SerializeField] private Transform[] redPoints;
    [SerializeField] private Transform[] greenPoints;
    [SerializeField] private Transform[] purplePoints;
    [SerializeField] private LineManager redLine;
    [SerializeField] private LineManager greenLine;
    [SerializeField] private LineManager purpleLine;

    private void Start()
    {
        redLine.SetUpLine(redPoints);
        greenLine.SetUpLine(greenPoints);
        purpleLine.SetUpLine(purplePoints);
    }
}
