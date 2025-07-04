using UnityEngine;

public class TrackWarning : MonoBehaviour
{
    [SerializeField] private LineColourEnum.LineColour obstacleColour;

    //Audio
    [SerializeField] AudioClip notifySound;
    [UnityEngine.Range(1, 10)]
    [SerializeField] float volume = 1f;

    public Animator redWarning;
    public Animator purpleWarning;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<FollowLine>().lineColour == obstacleColour)
            {
                redWarning.SetBool("redFlash", true);
                purpleWarning.SetBool("purpleFlash", true);
                SoundManager.instance.PlaySoundFXClip(notifySound, transform, volume);
            }
            else
            {
                redWarning.SetBool("redFlash", false);
                purpleWarning.SetBool("purpleFlash", false);
            }
        }
    }
}
