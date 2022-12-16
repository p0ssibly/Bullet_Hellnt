using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generat_Map : MonoBehaviour
{
    Dictionary<int, GameObject> tileset;
    Dictionary<int, GameObject> tilegroups;
    public GameObject grass_fab;

    int map_width = 160;
    int map_height = 90;

    List<List<int>> noise_grid = new List<List<int>>();
    List<List<GameObject>> tile_grid = new List<List<GameObject>>(); 

    float magnification = 7.0f;

    int x_offset = 0; // <- +>
    int y_offset = 0; // v- +^

    void Start()
    {
        CreateTileset();
        CreateTileGroups();
        GenerateMap();
    }

    void CreateTileset()
    {
        tileset = new Dictionary<int, GameObject>();
        tileset.Add(0, grass_fab);
    }

    void CreateTileGroups()
    {
        tilegroups = new Dictionary<int, GameObject>();
        foreach (KeyValuePair<int, GameObject> pair_fab in tileset)
        {
            GameObject tilegroup = new GameObject(pair_fab.Value.name);
            tilegroup.transform.parent = gameObject.transform;
            tilegroup.transform.localPosition = new Vector3(0, 0, 0);
            tilegroups.Add(pair_fab.Key, tilegroup);
        }
    }
    
    void GenerateMap()
    {
        for (int x = 0; x < map_width; x++)
        {
            noise_grid.Add(new List<int>());
            tile_grid.Add(new List<GameObject>());

            for (int y = 0; y < map_height; y++)
            {
                int tile_id = GetIdUsingPerlin(x, y);
                noise_grid[x].Add(tile_id);
                CreateTile(tile_id, x, y);
            }
        }
    }

    int GetIdUsingPerlin(int x, int y)
    {
        float raw_perlin = Mathf.PerlinNoise(
            (x - x_offset) / magnification,
            (y - y_offset) / magnification
        );
        float clamp_perlin = Mathf.Clamp(raw_perlin, 0.0f, 1.0f);
        float scaled_perlin = clamp_perlin * tileset.Count;
        if (scaled_perlin == tileset.Count)
        {
            scaled_perlin = (tileset.Count - 1);
        }
        return Mathf.FloorToInt(scaled_perlin);
    }
    
    void CreateTile(int tile_id, int x, int y)
    {
        GameObject tile_prefab = tileset[tile_id];
        GameObject tilegroup = tilegroups[tile_id];
        GameObject tile = Instantiate(tile_prefab, tilegroup.transform);
 
        tile.name = string.Format("tile_x{0}_y{1}", x, y);
        tile.transform.localPosition = new Vector3(x, y, 0);
 
        tile_grid[x].Add(tile);
    }
}
