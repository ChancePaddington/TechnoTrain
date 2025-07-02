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
        if(dialogueIndex <= sentences.Length - 1)
        {
            dialogueText.text = "";
            StartCoroutine(WriteSentences());
        }
        else
        {
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
