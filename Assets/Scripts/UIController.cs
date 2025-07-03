using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class UIController : MonoBehaviour
{
    public SpeedManager speedManager;
    public FollowLine followLine;
    public DialogueController dialogueController;

    //Animations
    public Animator transition;
    public float transitionTime;

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

    public void BrakeButton()
    {
        speedManager.Deceleration();
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
        StartCoroutine(LoadLevel(sceneIndex));
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
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
