using System.Collections;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public SpeedManager speedManager;
    public FollowLine followLine;
    public DialogueController dialogueController;

    //Audio
    [SerializeField] AudioClip dialogueNextSound; 
    [Range(1, 10)]
    [SerializeField] float volume = 1f;


    private void Start()
    {
        followLine = FindAnyObjectByType<FollowLine>();
        speedManager = FindAnyObjectByType<SpeedManager>();
        dialogueController = FindAnyObjectByType<DialogueController>();
    }

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

    public void NextDialogue()
    {
        dialogueController.NextSentence();
        SoundManager.instance.PlaySoundFXClip(dialogueNextSound, transform, volume);
    }

    public void SceneLoad(int sceneIndex)
    {
        SceneController.LoadScene(sceneIndex);
    }

    public void Restart()
    {
        SceneController.Restart();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
