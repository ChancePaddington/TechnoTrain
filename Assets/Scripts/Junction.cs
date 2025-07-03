using System.Collections;
using TMPro;
using UnityEngine;
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

    public int gameOver;
    private float transitionSpeed = 2f;

    private void Start()
    {
        speedManager = FindAnyObjectByType<SpeedManager>();
        ps = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        speedLimitSign.text = speedLimit + "Mph";
        
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
                //StartCoroutine(TransitionToGameOverScene());
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

        //IEnumerator TransitionToGameOverScene()
        //{
        //    yield return new WaitForSeconds(transitionSpeed);
        //    SceneController.LoadScene(gameOver);
        //}
    }

}
