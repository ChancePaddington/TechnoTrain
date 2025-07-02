using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class LapChange : MonoBehaviour
{
    private List<Junction> junctions;
    public SpeedManager speedManager;
    [SerializeField] private int lapSpeedLimit = 5;
    [SerializeField] private int lapMaxSpeed = 5;
    [SerializeField] private int lapDeceleration = 2;

    [SerializeField] public int lapNumber = 1;
    private int lapIncrease = 1;
    public TextMeshProUGUI lapNumberSign;
    public string currentLapScore;

    //Particle Effects
    public ParticleSystem ps;

    //Audio
    [SerializeField] AudioClip lapSound;
    [UnityEngine.Range(1, 10)]
    [SerializeField] float volume = 1f;

    private void Start()
    {
        junctions = FindObjectsByType<Junction>(FindObjectsSortMode.None).ToList();
        ps = GetComponentInChildren<ParticleSystem>();
        
    }

    private void Update()
    {
        lapNumberSign.text = "Lap: " + lapNumber;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Iterates across a list of Junctions 
            foreach (Junction junction in junctions)
            {
                junction.speedLimit += lapSpeedLimit;
            }
            lapNumber += lapIncrease;
            speedManager.maxSpeed = speedManager.maxSpeed += lapMaxSpeed;
            speedManager.decelerationSpeed = speedManager.decelerationSpeed += lapDeceleration;
            ps.Play();
            Debug.Log("Play Particles");
            SoundManager.instance.PlaySoundFXClip(lapSound, transform, volume);

        }
        
    }
}
