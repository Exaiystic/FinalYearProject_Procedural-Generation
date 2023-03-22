using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualiser tilemapVisualiser)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionsList);
        foreach (var position in basicWallPositions)
        {
            tilemapVisualiser.PaintSingleBasicWall(position);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        //Run through all floor tiles
        foreach (var position in floorPositions)
        {
            //Run through all directions
            foreach (var direction in directionList)
            {
                var neighbourPosition = position + direction;
                //If floor does not have adjacent floor tile
                if (floorPositions.Contains(neighbourPosition) == false) 
                {
                   //Mark as position for wall
                    wallPositions.Add(neighbourPosition);
                }
            }
        }
        return wallPositions;
    }
}
