using System.Collections;
using UnityEngine;

public class BrokenTrack : MonoBehaviour
{
    [SerializeField] private LineColourEnum.LineColour obstacleColour;

    //Audio
    [SerializeField] AudioClip destroySound;
    [UnityEngine.Range(1, 10)]
    [SerializeField] float volume = 1f;

    public int gameOver;
    private float transitionSpeed = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<FollowLine>().lineColour == obstacleColour)
            {
                collision.gameObject.SetActive(false);
                SoundManager.instance.PlaySoundFXClip(destroySound, transform, volume);
                StartCoroutine(TransitionToGameOverScene());
            }
        }
    }
    IEnumerator TransitionToGameOverScene()
    {
        yield return new WaitForSeconds(transitionSpeed);
        SceneController.LoadScene(gameOver);
    }
}
