using UnityEngine;

public class PurpleTrackWarning : MonoBehaviour
{
    [SerializeField] private LineColourEnum.LineColour obstacleColour;

    //Audio
    [SerializeField] AudioClip notifySound;
    [UnityEngine.Range(1, 10)]
    [SerializeField] float volume = 1f;

    public Animator redWarning;
    public Animator greenWarning;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<FollowLine>().lineColour == obstacleColour)
            {
                redWarning.SetBool("redFlash", true);
                greenWarning.SetBool("greenFlash", true);
                SoundManager.instance.PlaySoundFXClip(notifySound, transform, volume);
            }
            else
            {
                redWarning.SetBool("redFlash", false);
                greenWarning.SetBool("greenFlash", false);
            }
        }
    }
}
