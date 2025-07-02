using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] sentences;
    private int dialogueIndex = 0;
    public float dialogueSpeed;

    public int trackScene;

    private void Start()
    {
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
            TransitionNextScene();
        }
    }

    public void TransitionNextScene()
    {
        SceneController.LoadScene(trackScene);

    }
}
