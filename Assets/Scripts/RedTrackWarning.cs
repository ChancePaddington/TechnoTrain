using UnityEngine;

public class RedTrackWarning : MonoBehaviour
{
    [SerializeField] private LineColourEnum.LineColour obstacleColour;

    //Audio
    [SerializeField] AudioClip notifySound;
    [UnityEngine.Range(1, 10)]
    [SerializeField] float volume = 1f;

    public Animator greenWarning;
    public Animator purpleWarning;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<FollowLine>().lineColour == obstacleColour)
            {
                greenWarning.SetBool("greenFlash", true);
                purpleWarning.SetBool("purpleFlash", true);
                SoundManager.instance.PlaySoundFXClip(notifySound, transform, volume);
            }
            else
            {
                greenWarning.SetBool("greenFlash", false);
                purpleWarning.SetBool("purpleFlash", false);
            }
        }
    }
}
