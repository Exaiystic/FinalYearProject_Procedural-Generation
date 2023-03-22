using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomStates : MonoBehaviour
{
    [Header("References - Tiles")]
    [SerializeField] private TileBase combatTile;
    [SerializeField] private TileBase neutralTile;
    [SerializeField] private TileBase clearedTile;

    [Header("References - Components")]
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private LootSpawner lootSpawner;
    [SerializeField] private RoomTiles roomTiles;

    [Header("References - GameManager")]
    [SerializeField] private GameManager gameManager;

    private TileBase[] allTiles;
    private BoundsInt bounds;
    private bool enemiesSpawned = false;
    private List<GameObject> enemies = new List<GameObject>();

    private enum state
    {
        inactive,
        neutral,
        combat,
        cleared
    }

    private state currentState = state.neutral;

    private void Awake()
    {
        if (tilemap == null) {  tilemap = GetComponent<Tilemap>(); }
        if (enemySpawner == null) {  enemySpawner = GetComponent<EnemySpawner>(); }
        if (gameManager == null)
        {
            GameObject gm = GameObject.Find("GameManager");
            gameManager = gm.GetComponent<GameManager>();
        }
        if (lootSpawner == null) { lootSpawner = GetComponent<LootSpawner>(); }
        if (roomTiles == null) { roomTiles = GetComponent<RoomTiles>(); }
    }

    private void Start()
    {
        CustomEventSystem.current.onEnemyDeathEvent += RemoveEnemy;
        CustomEventSystem.current.onNewDungeonEvent += Reset;

        Init();
    }

    private void Init()
    {
        GetTiles();

        if (allTiles.Length == 0)
        {
            ChangeState(state.inactive);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!enemiesSpawned)
            {
                ChangeState(state.combat);
            }
        }
    }

    private void ChangeState(state targetState)
    {
        currentState = targetState;

        switch (currentState)
        {
            case state.inactive:
                SwapTiles(null);
                break;
            
            case state.neutral:
                SwapTiles(neutralTile);
                break;

            case state.cleared:
                SwapTiles(clearedTile);
                CustomEventSystem.current.RoomCleared(gameObject);
                lootSpawner.SpawnLoot();
                //gameManager.RoomCleared(gameObject);
                break;

            case state.combat:
                if (!enemiesSpawned)
                {
                    enemies.AddRange(enemySpawner.SpawnEnemies());
                    SwapTiles(combatTile);
                    enemiesSpawned = true;
                }
                break;
        }
    }

    private void SwapTiles(TileBase newTile)
    {
        List<Vector3Int> coords = roomTiles.GetCoords();

        foreach (Vector3Int pos in coords)
        {
            tilemap.SetTile(pos, newTile);
        }
    }

    private void GetTiles()
    {
        bounds = tilemap.cellBounds;
        allTiles = tilemap.GetTilesBlock(bounds);
    }

    private void RemoveEnemy(GameObject enemy)
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }

        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
            if (enemies.Count == 0)
            {
                ChangeState(state.cleared);
            }
        }

    }

    private void Reset()
    {
        currentState = state.neutral;
        enemiesSpawned = false;

        Init();
    }

    public string ReturnRoomState()
    {
        return currentState.ToString();
    }
}
