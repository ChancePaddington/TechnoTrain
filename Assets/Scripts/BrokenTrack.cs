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
    public int damage = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<FollowLine>().lineColour == obstacleColour)
            {
                Health health = collision.gameObject.GetComponent<Health>();
                Debug.Log("Calling Health script");
                if (health != null)
                {
                    Debug.Log("Taking damage");
                    health.TakeDamage(damage);
                }
                SoundManager.instance.PlaySoundFXClip(destroySound, transform, volume);
            }
        }
    }
}
