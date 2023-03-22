using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Inheriting from the random walk generator so that we can access the RunRandomWalk() function
public class CorridorFirstDungeonGenerator : RWGenerator
{
    [SerializeField] private int corridorLength = 14, corridorCount = 5;
    [SerializeField] [Range(0.1f, 1)] private float roomPercent = 0.8f;

    private int numberOfRooms = 0;

    protected override void RunPCG()
    {
        CorridorFirstDungeonGeneration();
    }

    private void CorridorFirstDungeonGeneration()
    {
        //Runs the corridor generation func
        HashSet<Vector2Int> floorPos = new HashSet<Vector2Int>();
        HashSet<Vector2Int> potentialRoomPositions = new HashSet<Vector2Int>();

        tilemapVisualiser.SetUpGameObjects(true);
        createCorridors(floorPos, potentialRoomPositions);

        HashSet<Vector2Int> roomPositions = CreateRooms(potentialRoomPositions);

        //Finding dead ends
        List<Vector2Int> deadEnds = FindAllDeadEnds(floorPos);
        CreateRoomsAtDeadEnds(deadEnds, roomPositions);

        //Painting only the room tiles
        //tilemapVisualiser.PaintFloorTiles(roomPositions, true);

        floorPos.UnionWith(roomPositions);

        //Creates tilemap around HashSet
        tilemapVisualiser.PaintFloorTiles(floorPos, false);
        WallGenerator.CreateWalls(floorPos, tilemapVisualiser);
    }

    private void CreateRoomsAtDeadEnds(List<Vector2Int> deadEnds, HashSet<Vector2Int> roomFloors)
    {
        foreach (var pos in deadEnds)
        {
            if(roomFloors.Contains(pos) == false)
            {
                HashSet<Vector2Int> room = RunRandomWalk(walkParameters, pos);
                numberOfRooms++;
                tilemapVisualiser.PaintFloorTiles(room, true);
                roomFloors.UnionWith(room);
            }
        }
    }

    private List<Vector2Int> FindAllDeadEnds(HashSet<Vector2Int> floorPos)
    {
        List<Vector2Int> deadEnds = new List<Vector2Int>();

        //Looping through all the floorpositions and searching for adjacent tiles, which will lead to a dead end
        foreach (var pos in floorPos)
        {
            int neighborsCount = 0;
            foreach (var direction in Direction2D.cardinalDirectionsList)
            {
                if(floorPos.Contains(pos + direction))
                {
                    neighborsCount++;
                }
            }
            if(neighborsCount == 1)
            {
                deadEnds.Add(pos);
            }
        }
        return deadEnds;
    }

    private HashSet<Vector2Int> CreateRooms(HashSet<Vector2Int> potentialRoomPositions)
    {
        HashSet<Vector2Int> roomPositions = new HashSet<Vector2Int>();

        //Getting how much of the generated layout we want to be rooms
        int roomToCreateCount = Mathf.RoundToInt(potentialRoomPositions.Count * roomPercent);
        numberOfRooms = roomToCreateCount;

        //Gives each pos a GUID - each id is random so we can randomly sort our hashset and store it as a list
        List<Vector2Int> roomsToCreate = potentialRoomPositions.OrderBy(x => Guid.NewGuid()).Take(roomToCreateCount).ToList();

        //Where we want to create a room we use our random walk to generate said room
        foreach (var roomPos in roomsToCreate)
        {
            HashSet<Vector2Int> roomFloor = RunRandomWalk(walkParameters, roomPos);
            tilemapVisualiser.PaintFloorTiles(roomFloor, true);
            roomPositions.UnionWith(roomFloor);
        }

        return roomPositions;
    }

    //Corridor creation func
    private void createCorridors(HashSet<Vector2Int> floorPos, HashSet<Vector2Int> potentialRoomPositions)
    {
        var currentPos = startPosition;

        //Our current position can potentially be used to start a walk for a room
        potentialRoomPositions.Add(currentPos);

        //Loop for however many corridors we want
        for (int i = 0; i < corridorCount; i++)
        {
            //Get a corridor using the algorithm from PCGAlgorithm (get one direction and go in that path for however many steps)
            var corridor = PCGAlgorithm.RandomWalkCorridor(currentPos, corridorLength);
            currentPos = corridor[corridor.Count - 1];
            potentialRoomPositions.Add(currentPos);
            //Add corridor elements to floorPos
            floorPos.UnionWith(corridor);
        }
    }

    public int GetNumberOfRooms()
    {
        return numberOfRooms;
    }
}
