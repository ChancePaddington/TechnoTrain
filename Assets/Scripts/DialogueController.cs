using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] sentences;
    private int dialogueIndex = 0;
    public float dialogueSpeed;
    public Animator dialogueAnimator;
    private bool startDialogue;

    public int trackScene;

    //Audio
    [SerializeField] AudioClip dialogueRadioPickUp;
    [SerializeField] AudioClip dialogueRadioPutDown;
    [Range(1, 10)]
    [SerializeField] float volume = 1f;

    private void Start()
    {
        dialogueAnimator.SetTrigger("Enter");
        NextSentence();
    }

    IEnumerator WriteSentences()
    {
        foreach (char Character in sentences[dialogueIndex].ToCharArray())
        {
            dialogueText.text += Character;
            yield return new WaitForSeconds(dialogueSpeed);
        }
        
        dialogueIndex++;
    }

    public void NextSentence()
    {
        SoundManager.instance.PlaySoundFXClip(dialogueRadioPickUp, transform, volume);

        if(dialogueIndex <= sentences.Length - 1)
        {
            dialogueText.text = "";
            StartCoroutine(WriteSentences());
        }
        else
        {
            SoundManager.instance.PlaySoundFXClip(dialogueRadioPutDown, transform, volume);
            dialogueText.text = "";
            dialogueAnimator.SetTrigger("Exit");
            TransitionNextScene();
        }
    }

    public void TransitionNextScene()
    {
        SceneController.LoadScene(trackScene);

    }
}
