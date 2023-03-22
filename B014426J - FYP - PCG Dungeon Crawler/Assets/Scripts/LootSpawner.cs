using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LootSpawner : MonoBehaviour
{
    [Header("Loot")]
    [SerializeField] private GameObject[] weapons;

    [Header("Other")]
    [SerializeField] private RoomTiles roomTiles;

    private List<Vector3Int> coordinates = new List<Vector3Int>();

    private void Awake()
    {
        if (roomTiles == null)
        { roomTiles = GetComponent<RoomTiles>(); }
    }

    private void Start()
    {
        coordinates = roomTiles.GetCoords();
    }

    public void SpawnLoot()
    {
        Instantiate(weapons[Random.Range(0, weapons.Length)], coordinates[GetMedianCoord()], Quaternion.identity);
    }

    private int GetMedianCoord()
    {
        return (int)Mathf.Round(coordinates.Count / 2);
    }
}
