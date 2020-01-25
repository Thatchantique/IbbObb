using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;


public class TileAutomater : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;

    [SerializeField] private TileBase tile;

    [SerializeField] private int width, height;

    [SerializeField] private bool useRandomSeed;

    [SerializeField] private int seed;

    [Range(0, 100), SerializeField] private int fillPercent;

    private void Start()
    {
        var map = new int[width, height];
        if (useRandomSeed)
            seed = Random.Range(int.MinValue, int.MaxValue);
        Random.InitState(seed);
        map = PerlinNoise(map);
        // map = RandomWalkTopSmoothed(map, 2);
        // map = GenerateCellularAutomata(map, fillPercent, false);
        // map = SmoothVnCellularAutomata(map, false, 1);
        // map = SmoothMooreCellularAutomata(map, false, 1);
        RenderMap(map);
    }

    //private int[,] RandomWalkTopSmoothed(int[,] map, int i)
    //{
    //    throw new System.NotImplementedException();
    //}

    private int[,] PerlinNoise(int[,] map)
    {
        //Used to reduced the position of the Perlin point
        const float reduction = 0.5f;
        var noiseSeed = Random.value;
        //Create the Perlin
        for (var x = 0; x < width; x++)
        {
            var newPoint = Mathf.FloorToInt((Mathf.PerlinNoise(x, noiseSeed) - reduction) * height);
            //Make sure the noise starts near the halfway point of the height
            newPoint += (height / 2);
            for (var y = newPoint; y >= 0; y--)
            {
                map[x, y] = 1;
            }
        }

        return map;
    }
    
    public void RenderMap(int[,] map)
    {
        tilemap.ClearAllTiles();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map[x, y] == 1)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}