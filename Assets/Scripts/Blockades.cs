using UnityEngine;

public class Blockades : MonoBehaviour
{
    public SpeedManager speedManager;

    //Audio
    [SerializeField] AudioClip decelerationSound;
    [Range(1, 10)]
    [SerializeField] float volume = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collidercollidin");
            speedManager.Deceleration();
            SoundManager.instance.PlaySoundFXClip(decelerationSound, transform, volume);
        }
    }
}
