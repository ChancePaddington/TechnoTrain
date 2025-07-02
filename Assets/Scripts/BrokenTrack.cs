using UnityEngine;

public class BrokenTrack : MonoBehaviour
{
    [SerializeField] private LineColourEnum.LineColour obstacleColour;

    //Audio
    [SerializeField] AudioClip destroySound;
    [UnityEngine.Range(1, 10)]
    [SerializeField] float volume = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<FollowLine>().lineColour == obstacleColour)
            {
                collision.gameObject.SetActive(false);
                SoundManager.instance.PlaySoundFXClip(destroySound, transform, volume);
            }
        }
    }
}
