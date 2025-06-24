using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class TrainTile : MonoBehaviour
{
    [SerializeField] private int x, y;

    private bool isTaken;
    public bool IsTaken
    {
        get => isTaken;
        set
        {
            isTaken = value;
            if (value == true) GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
        }
    }

    private bool hasJunction;
    public bool HasJunction
    {
        get => hasJunction;
        set
        {
            hasJunction = value;
            GetComponentInChildren<SpriteRenderer>().color = value == true? Color.red : Color.grey;
            name += " (Junction)";
        }
    }

    private void Awake()
    {
        HasJunction = false;
    }

    public Tuple<int, int> Coordinates
    {
        get => new Tuple<int, int>(x, y);
        set
        {
            x = value.Item1;
            y = value.Item2;

            name = $"{x}, {y}";
        }
    }
}
