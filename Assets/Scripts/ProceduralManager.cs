using System.Collections.Generic;
using UnityEngine;

public class ProceduralManager : MonoBehaviour
{
    //Singleton with an added protection level
    public static ProceduralManager instance { get; private set; }

    [SerializeField] private GameObject redWaypointPrefab;

    [SerializeField] public List<Transform> junctions;
    [SerializeField] public List<Transform> redWaypoints;
    [SerializeField] public List<Transform> greenWaypoints;
    [SerializeField] public List<Transform> purpleWaypoints;
    [SerializeField] public List<Transform> currentLineArray;
    [SerializeField] public int currentWaypointIndex;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CreateMap();
    }

    void CreateMap()
    {
        float randJunctionX = Random.Range(10f, 20f);
        float randJunctionY = Random.Range(10f, 20f);


    }

    //Populate list with prefabs
}
