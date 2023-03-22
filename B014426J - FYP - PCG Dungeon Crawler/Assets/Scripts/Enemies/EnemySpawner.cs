using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int spawnCount = 20;

    [Header("Enemy References")]
    [SerializeField] private GameObject[] spawnableEnemies;
    [SerializeField] private GameObject startEnemy;

    [Header("Other References")]
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private RoomTiles roomTiles;
    [SerializeField] private GameManager gameManager;

    private List<TileBase> allTiles = new List<TileBase>();
    private List<Vector3Int> allTileCoords = new List<Vector3Int>();
    List<GameObject> spawnedEnemies = new List<GameObject>();

    private List<float> spawnCosts = new List<float>();

    private BoundsInt bounds;

    private void Awake()
    {
        if (roomTiles == null)
        { roomTiles = GetComponent<RoomTiles>(); }
        
        if (tilemap == null)
        { tilemap = GetComponent<Tilemap>(); }

        if (gameManager == null)
        { 
            GameObject temp = GameObject.Find("GameManager");
            gameManager = temp.GetComponent<GameManager>();
        }
    }

    private void Start()
    {
        CustomEventSystem.current.onNewDungeonEvent += Init;

        Init();
    }

    private void Init()
    {
        /*
        //Getting all tiles from tilemap
        bounds = tilemap.cellBounds;
        allTiles.AddRange(tilemap.GetTilesBlock(bounds));

        //Removing nulls from list
        RemoveNullsFromList(allTiles);
        */

        //Getting the room's tiles
        allTiles = roomTiles.GetTiles();

        //Getting all valid coordinates
        allTileCoords = roomTiles.GetCoords();
        //GetValidCoords();
    }

    public List<GameObject> SpawnEnemies()
    {
        //Places where enemies can be spawned
        List<Vector3> spawnablePlaces = new List<Vector3>();

        //Setting up enemies that can be afforded
        List<GameObject> affordableEnemies = new List<GameObject>();
        affordableEnemies.AddRange(spawnableEnemies);

        //Getting the index of the room - determines what and how many enemies can be spawned
        float roomIndex = gameManager.ReturnRoomIndex();

        //Getting spawn locations
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3Int targetCoord = allTileCoords[Random.Range(0, allTileCoords.Count)];
            spawnablePlaces.Add(targetCoord);
        }

        //List<GameObject> spawnedEnemies = new List<GameObject>();

        if (roomIndex != 0)
        {
            for (int i = 0; i < spawnablePlaces.Count; i++)
            {
                //Removing enemies too expensive from the pool
                RemoveUnaffordableEnemies(roomIndex, affordableEnemies);

                //If enemies can still be afforded
                if (affordableEnemies.Count > 0)
                {
                    //Instantiating random enemy
                    GameObject go = Instantiate(affordableEnemies[Random.Range(0, affordableEnemies.Count)], spawnablePlaces[i], Quaternion.identity);

                    //Deducting the cost of the enemy from the index
                    EnemyAI enemy = go.GetComponent<EnemyAI>();
                    roomIndex -= enemy.ReturnCost();

                    //Adding to list of spawned enemies
                    spawnedEnemies.Add(go);
                    Debug.Log(go.name + " spawned at " + spawnablePlaces[i]);
                }
            }
        } else
        {
            Vector3 pos = spawnablePlaces[Random.Range(0, spawnablePlaces.Count)];
            GameObject go = Instantiate(startEnemy, pos, Quaternion.identity);
            spawnedEnemies.Add(go);
            Debug.Log(go.name + " spawned at " + pos);
        }

        return spawnedEnemies;
    }

    private void RemoveUnaffordableEnemies(float totalIndex, List<GameObject> enemies)
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            EnemyAI enemy = enemies[i].GetComponent<EnemyAI>();
            float cost = enemy.ReturnCost();
            if (cost > totalIndex)
            {
                enemies.RemoveAt(i);
            }
        }
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
    }

    private Vector3Int GetRandomCoord()
    {
        Vector3Int random = new Vector3Int(Random.Range(0, bounds.size.x), Random.Range(0, bounds.size.y), 0);
        return random;
    }

    private void RemoveNullsFromList(List<TileBase> allTiles)
    {
        for (int i = allTiles.Count - 1; i > -1; i--)
        {
            if (allTiles[i] == null)
                { allTiles.RemoveAt(i); }
        };
    }
}