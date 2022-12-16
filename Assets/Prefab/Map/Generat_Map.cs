using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generat_Map : MonoBehaviour
{
    Dictionary<int, GameObject> tileset;
    Dictionary<int, GameObject> tilegroups;
    public GameObject grass_fab;

    void Start()
    {
        CreateTileset();
        CreateTileGroups();
    }

    void CreateTileset()
    {
        tileset = new Dictionary<int, GameObject>();
        tileset.Add(0, grass_fab);
    }

    void CreateTileGroups()
    {
        tilegroups = new Dictionary<int, GameObject>();
        foreach (KeyValuePair<int, GameObject> grass_fab in tileset)
        {
            GameObject tilegroups = new GameObject(grass_fab.Value.name);
        }
    }
}
