using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering;

public class Junction : MonoBehaviour
{
    private SpeedManager speedManager;
    [SerializeField] private Transform reset;
    [SerializeField] public int damage = 5;

    //UI
    [SerializeField] public int speedLimit;
    public TextMeshProUGUI speedLimitSign;

    //Particle Effects
    public ParticleSystem ps;

    //Audio
    [SerializeField] AudioClip junctionSound;
    [SerializeField] AudioClip alarmSound;
    [Range(0, 10)]
    [SerializeField] float volume = 1f;

    //Animations
    public Animator speedWarning;
    public Animator greenWarning;
    public Animator redWarning;
    public Animator purpleWarning;

    private void Start()
    {
        speedManager = FindAnyObjectByType<SpeedManager>();
        ps = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        speedLimitSign.text = speedLimit * 10 + "Mph";

        float playerSpeed = speedManager.currentSpeed;  
        if (playerSpeed > speedLimit - 1)
        {
            speedWarning.SetBool("speedBool", true);
            //SoundManager.instance.PlaySoundFXClip(alarmSound, transform, volume);
        }
        else
        {
            speedWarning.SetBool("speedBool", false); 
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Create variable to check players speed on collision
            Debug.Log("Train touched");
            float playerSpeed = speedManager.currentSpeed;

            //If less than set speed limit
            if (playerSpeed > speedLimit)
            {
                Health health = collision.gameObject.GetComponent<Health>();
                Debug.Log("Calling Health script");
                if (health != null)
                {
                    Debug.Log("Taking damage");
                    health.TakeDamage(damage);
                }
               
            }
            else
            {
                Debug.Log("Play Particles");
                ps.Play();
                SoundManager.instance.PlaySoundFXClip(junctionSound, transform, volume);
                greenWarning.SetBool("greenFlash", false);
                redWarning.SetBool("redFlash", false);
                purpleWarning.SetBool("purpleFlash", false);
            }
        }
    }

}
