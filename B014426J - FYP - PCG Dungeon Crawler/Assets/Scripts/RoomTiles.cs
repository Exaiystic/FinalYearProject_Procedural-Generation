using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class RoomTiles : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    
    private List<TileBase> allTiles = new List<TileBase>();
    private List<Vector3Int> allTileCoords = new List<Vector3Int>();
    private BoundsInt bounds;

    private void Awake()
    {
        if (tilemap == null)
        { tilemap = GetComponent<Tilemap>(); }
    }

    void Start()
    {
        CustomEventSystem.current.onNewDungeonEvent += Init;

        Init();
    }

    private void Init()
    {
        allTileCoords.Clear();
        allTiles.Clear();
        
        //Getting all tiles from tilemap
        bounds = tilemap.cellBounds;
        allTiles.AddRange(tilemap.GetTilesBlock(bounds));

        //Removing nulls from list
        RemoveNullsFromList(allTiles);

        //Storing the valid tile coordinates
        GetValidCoords();
    }

    private void RemoveNullsFromList(List<TileBase> allTiles)
    {
        for (int i = allTiles.Count - 1; i > -1; i--)
        {
            if (allTiles[i] == null)
            { allTiles.RemoveAt(i); }
        };
    }
    private void GetValidCoords()
    {
        foreach (Vector3Int position in tilemap.cellBounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(position);
            if (allTiles.Contains(tile))
            {
                allTileCoords.Add(position);
            }
        }

        //Sorting the coords
        allTileCoords = allTileCoords.OrderBy(v => v.x).ToList();
    }

    public List<TileBase> GetTiles()
    {
        return allTiles;
    }

    public List<Vector3Int> GetCoords()
    {
        return allTileCoords;
    }
}
