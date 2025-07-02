using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TMPro;
using UnityEngine;

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

    private void Start()
    {
        junctions = FindObjectsByType<Junction>(FindObjectsSortMode.None).ToList();
    }

    private void Update()
    {
        lapNumberSign.text = "Lap: " + lapNumber;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // iterate across every Junction in the list of junctions, and apply the following line to each of them
            foreach (Junction junction in junctions)
            {
                junction.speedLimit += lapSpeedLimit;
            }
            lapNumber += lapIncrease;
            speedManager.maxSpeed = speedManager.maxSpeed += lapMaxSpeed;
            speedManager.decelerationSpeed = speedManager.decelerationSpeed += lapDeceleration;
        }
        
    }
}
