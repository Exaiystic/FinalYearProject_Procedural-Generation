using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PCGAlgorithm
{
    public static HashSet<Vector2Int> simpleRandomWalk(Vector2Int startPosition, int walkLength)
    {
        //Set for outputted path
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        //Add the first position
        path.Add(startPosition);
        //Set start pos as previous being as there will only be 1 pos at first
        var previousPosition = startPosition;

        //Generating path
        for (int i = 0; i < walkLength; i++)
        {
            //Create new tile in path and add it to set
            var newPosition = previousPosition + Direction2D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }
        return path;
    }

    //New list for corridor data
    public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPos, int corriderLength)
    {
        List<Vector2Int> corridor = new List<Vector2Int>();
        //Get random direction - because this is a corridor we only need one direction for the path
        var direction = Direction2D.GetRandomCardinalDirection();
        //Make currentpos var and set it to initial position
        var currentPos = startPos;
        //Add currentpos to out corridor list
        corridor.Add(currentPos);

        //Perform random walk on a corridor
        for (int i = 0; i < corriderLength; i++)
        {
            currentPos += direction;
            corridor.Add(currentPos);
        }
        return corridor;
    }
}

public static class Direction2D
{
    //Possible directions that the walk can move in
    public static List<Vector2Int> cardinalDirectionsList = new List<Vector2Int>
    {
        new Vector2Int(0, 1), //UP
        new Vector2Int(1, 0), //RIGHT
        new Vector2Int(0, -1), //DOWN
        new Vector2Int(-1, 0) //LEFT
    };

    //Getting a random direction from the possible directions
    public static Vector2Int GetRandomCardinalDirection()
    {
        return cardinalDirectionsList[Random.Range(0, cardinalDirectionsList.Count)];
    }
}
