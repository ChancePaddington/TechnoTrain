using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BrokenTrack : MonoBehaviour
{
    [SerializeField] private LineColourEnum.LineColour obstacleColour;

    //Audio
    [SerializeField] AudioClip destroySound;
    [UnityEngine.Range(1, 10)]
    [SerializeField] float volume = 1f;

    public GameObject endScreen;
    public GameObject hud;

    //public int gameOver;
    //private float transitionSpeed = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<FollowLine>().lineColour == obstacleColour)
            {
                collision.gameObject.SetActive(false);
                SoundManager.instance.PlaySoundFXClip(destroySound, transform, volume);
                endScreen.SetActive(true);
                hud.SetActive(false);
                //StartCoroutine(TransitionToGameOverScene());
            }
        }
    }
    //IEnumerator TransitionToGameOverScene()
    //{
    //    yield return new WaitForSeconds(transitionSpeed);
    //    SceneController.LoadScene(gameOver);
    //}
}
