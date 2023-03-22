using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

//Deriving from AbstractDungeonGenerator
public class RWGenerator : AbstractDungeonGenerator
{

    [SerializeField] protected RWSO walkParameters;

    protected override void RunPCG()
    {
        //Getting floor positions, and then applying them as a tilemap - have to make sure that the previously generated tilemap is cleared
        HashSet<Vector2Int> floorPositions = RunRandomWalk(walkParameters, startPosition);
        tilemapVisualiser.Clear();
        //tilemapVisualiser.PaintFloorTiles(floorPositions);
        //Adding walls
        WallGenerator.CreateWalls(floorPositions, tilemapVisualiser);
    }

    //We have added the parameters to the function so that child classes can access the func - this is important as our corridor generation will need this!
    protected HashSet<Vector2Int> RunRandomWalk(RWSO parameters, Vector2Int position)
    {
        var currentPosition = position;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        
        //Repeating the walk for however many iterations there are
        for (int i = 0; i < parameters.iterations; i++)
        {
            var path = PCGAlgorithm.simpleRandomWalk(currentPosition, parameters.walkLength);
            floorPositions.UnionWith(path);
            if(parameters.startRandomlyEachIteration)
            {
                //If iterations don't start from the centre, choose a random place to start
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
        }
    return floorPositions;
    }
}
