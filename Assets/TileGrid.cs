using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TileGrid : MonoBehaviour
{
    [SerializeField] int height = 9;
    [SerializeField] int width = 16;

    [SerializeField] GameObject columnPrefab, tilePrefab;

    [SerializeField] List<GameObject> columns = new List<GameObject>();
    [SerializeField] HorizontalLayoutGroup rows;

    private void Start()
    {
        PopulateGrid();

        SetNewJunctionPoint();
    }

    private void SetNewJunctionPoint()
    {
        var randomX = Random.Range(0, width - 1);
        var randomY = Random.Range(0, height - 1);

        while (GetTileByCoordinates(randomX, randomY).IsTaken)
        {
            randomX = Random.Range(0, width);
            randomY = Random.Range(0, height);
        }

        GetTileByCoordinates(randomX, randomY).IsTaken = true;
        for (int j = -1; j <= 1; j++)
        {
            for (int k = -1; k <= 1; k++)
            {
                var adjacentX = randomX + j;
                var adjacentY = randomY + k;

                if (adjacentX < 0 || adjacentY < 0) continue;

                TrainTile adjacentTile = GetTileByCoordinates(adjacentX, adjacentY);
                if (!adjacentTile.IsTaken) adjacentTile.IsTaken = true;
            }
        }

        AddJunctionToTile(randomX, randomY);
    }

    private void PopulateGrid()
    {
        rows.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

        for (int i = 0; i < width; i++)
        {
            var newColumn = Instantiate(columnPrefab, rows.transform);
            newColumn.GetComponent<RectTransform>().sizeDelta = new Vector2(1, height);
            newColumn.name = $"Column {i}";
            columns.Add(newColumn);
            for (int j = 0; j < height; j++)
            {
                var newTile = Instantiate(tilePrefab, newColumn.transform);
                newTile.GetComponent<TrainTile>().Coordinates = new Tuple<int, int>(i, j);
            }
        }
    }

    private void AddJunctionToTile(int x, int y)
    {
        var selectedTile = GetTileByCoordinates(x, y);
        selectedTile.HasJunction = true;
    }

    private TrainTile GetTileByCoordinates(int x, int y)
    {
        foreach (var tile in FindObjectsByType<TrainTile>(FindObjectsSortMode.None))
        {
            if (tile.Coordinates.Item1 == x && tile.Coordinates.Item2 == y)
            {
                return tile;
            }
        }
        Debug.LogError($"No tile with coordinates {x}, {y} found!");
        return null;
    }
}
