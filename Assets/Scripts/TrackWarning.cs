using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Rendering;

public class GreenTrackWarning : MonoBehaviour
{
    [SerializeField] private LineColourEnum.LineColour obstacleColour;

    //Audio
    [SerializeField] AudioClip destroySound;
    [UnityEngine.Range(1, 10)]
    [SerializeField] float volume = 1f;

    public Animator greenWarning;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<FollowLine>().lineColour == obstacleColour)
            {
                greenWarning.SetBool("greenFlash", true);
                SoundManager.instance.PlaySoundFXClip(destroySound, transform, volume);
            }
            else
            {
                greenWarning.SetBool("greenFlash", false);
            }
        }
    }
}
