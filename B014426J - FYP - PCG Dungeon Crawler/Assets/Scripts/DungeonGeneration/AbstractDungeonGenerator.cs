using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDungeonGenerator : MonoBehaviour
{
    [SerializeField] protected TilemapVisualiser tilemapVisualiser = null;
    [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;

    public void GenerateDungeon()
    {
        //Clear current tilemap before generating new one
        tilemapVisualiser.Clear();
        //Generating new layout
        RunPCG();
    }

    protected abstract void RunPCG();
}
