using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualiser : MonoBehaviour
{
    [SerializeField] private CorridorFirstDungeonGenerator cfDungeonGenerator;
    
    [Header("Room References")]
    [SerializeField] private GameObject roomAsset;
    [SerializeField] private Transform gridTransform;
    
    [Header("Tilemap References")]
    [SerializeField] private Tilemap corridorFloorTilemap;
    [SerializeField] private Tilemap wallTilemap;

    [Header("Sprite References")]
    [SerializeField] private TileBase floorTile;
    [SerializeField] private TileBase wallTop;

    private List<GameObject> roomFloorGameObjects = new List<GameObject>();
    private List<Tilemap> roomFloorTilemaps = new List<Tilemap>();
    private int roomIndex = 0;

    public void SetUpGameObjects(bool firstTime)
    {
        int roomCount = cfDungeonGenerator.GetNumberOfRooms();
        SpawnRoomGameObjects(roomCount, firstTime);
    }

    private void GetTilemapsOfRooms(int count, bool firstTime)
    {
        if (firstTime)
        {
            roomFloorTilemaps.Clear();
        }
        
        for (int i = 0; i < count; i++)
        {
            roomFloorTilemaps.Add(roomFloorGameObjects[i].GetComponent<Tilemap>());
            roomFloorTilemaps[i].ClearAllTiles();
        }
    }
    
    private void SpawnRoomGameObjects(int count, bool firstTime)
    {
        roomFloorGameObjects.Clear();
        //Removing any missing gameobjects within the list
        if (roomFloorGameObjects != null)
        {
            for (int i = roomFloorGameObjects.Count - 1; i > -1; i--)
            {
                if (roomFloorGameObjects[i] == null)
                {
                    roomFloorGameObjects.RemoveAt(i);
                }
            }
        }

        //Bring any room gameObjects lying around into the list
        GameObject[] gameObjs = GameObject.FindGameObjectsWithTag("SpawnableGround");
        for (int i = 0; i < gameObjs.Length; i++)
        {
            if (gameObjs[i].name == "RoomPrefab(Clone)")
            {
                roomFloorGameObjects.Add(gameObjs[i]);
            }
        }
        
        //Regenerating rooms if the target count is not reached
        if (roomFloorGameObjects.Count != count)
        {
            int roomsToAdd = count - roomFloorGameObjects.Count;
            
            for (int i = 0; i < roomsToAdd; i++)
            {
                roomFloorGameObjects.Add(Instantiate(roomAsset, gridTransform));
            }
        }

        if (firstTime)
        {
            roomIndex = 0;
        }
        GetTilemapsOfRooms(roomFloorGameObjects.Count, firstTime);
        //GetTilemapsOfRooms(count, firstTime);
    }
    
    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions, bool forRoom)
    {
        //SetUpGameObjects(false);
        
        if (forRoom)
        {
            PaintTiles(floorPositions, roomFloorTilemaps[roomIndex], floorTile);
            roomIndex++;
        } else
        {
            PaintTiles(floorPositions, corridorFloorTilemap, floorTile);
        }
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        {
            //Looping through all the positions and applying a sprite to them
            foreach (var position in positions)
            {
                PaintSingleTile(tilemap, tile, position);
            }
        }
    }

    internal void PaintSingleBasicWall(Vector2Int position)
    {
        PaintSingleTile(wallTilemap, wallTop, position);
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        //Applying sprite
        Vector3Int tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        corridorFloorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();  
    }
}
