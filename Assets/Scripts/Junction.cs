using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering;

public class Junction : MonoBehaviour
{
    private SpeedManager speedManager;
    [SerializeField] private Transform reset;

    //UI
    [SerializeField] public int speedLimit;
    public TextMeshProUGUI speedLimitSign;
    public GameObject hud;
    public GameObject endScreen;

    //Particle Effects
    public ParticleSystem ps;

    //Audio
    [SerializeField] AudioClip junctionSound;
    [Range(1, 10)]
    [SerializeField] float volume = 1f;

    //Animations
    public Animator speedWarning;

    public int gameOver;
    private float transitionSpeed = 2f;

    private void Start()
    {
        speedManager = FindAnyObjectByType<SpeedManager>();
        ps = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        speedLimitSign.text = speedLimit * 10 + "Mph";

        float playerSpeed = speedManager.currentSpeed;  
        if (playerSpeed > speedLimit)
        {
            speedWarning.SetBool("speedBool", true);
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
                collision.gameObject.SetActive(false);
                endScreen.SetActive(true);
                hud.SetActive(false);
            }
            else
            {
                Debug.Log("Play Particles");
                ps.Play();
                SoundManager.instance.PlaySoundFXClip(junctionSound, transform, volume);
            }
        }
    }

}
