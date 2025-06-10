using UnityEngine;

public class UIController : MonoBehaviour
{
    public SpeedManager speedManager;
    public FollowLine followLine;

    public void BeatButton()
    {
        speedManager.MoveOnBeat();
    }

    public void ChangeToGreen()
    {
        followLine.SwitchToGreenLine();
    }

    public void ChangeToPurple()
    {
        followLine.SwitchToPurpleLine();
    }

    public void ChangeToRed()
    {
        followLine.SwitchToRedLine();
    }
}
