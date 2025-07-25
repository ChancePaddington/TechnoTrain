using UnityEngine;
using UnityEngine.Rendering;

public class SoundLoopManager : MonoBehaviour
{
    [SerializeField] public AudioClip alarmSound;
    [Range(1, 10)]
    [SerializeField] float volume = 1f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = SoundManager.instance.PlayLoopFXSound(alarmSound, transform, volume);
    }

    public void Stop()
    {
        Destroy(audioSource.gameObject);
    }
}
