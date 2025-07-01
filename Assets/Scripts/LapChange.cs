using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class LapChange : MonoBehaviour
{
    private List<Junction> junctions;
    public SpeedManager speedManager;
    private int lapSpeedLimit = 5;
    private int lapMaxSpeed = 5;
    private int lapDeceleration = 2;

    private void Start()
    {
        junctions = FindObjectsByType<Junction>(FindObjectsSortMode.None).ToList();
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
            speedManager.maxSpeed = speedManager.maxSpeed += lapMaxSpeed;
            speedManager.decelerationSpeed = speedManager.decelerationSpeed += lapDeceleration;
        }
        
    }
}
