using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Settings - Spawning")]
    [SerializeField] private float initialRoomIndex = 700f;
    [SerializeField] private float roomIndexIncrement = 500f;

    [Header("Settings - Setup")]
    [SerializeField] private string roomTag = "SpawnableGround";
    [SerializeField] private string roomName = "RoomPrefab(Clone)";

    [Header("References")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject floorCompletedScreen;

    private List<GameObject> rooms = new List<GameObject>();

    private float currentRoomIndex;
    private bool isFirstRoom = true;

    private void Awake()
    {
        if (gameOverScreen == null)
        { gameOverScreen = GameObject.Find("GameOverScreen"); }

        if (floorCompletedScreen == null)
        { floorCompletedScreen = GameObject.Find("FloorCompletedScreen"); }
    }

    private void Start()
    {
        CustomEventSystem.current.onRoomClearedEvent += RoomCleared;
        CustomEventSystem.current.onNewDungeonEvent += Init;
        CustomEventSystem.current.onPlayerDeathEvent += PlayerDeath;

        currentRoomIndex = initialRoomIndex;
        Init();
    }
    private void Init()
    {
        floorCompletedScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        isFirstRoom = true;

        foreach (GameObject spawnableGround in GameObject.FindGameObjectsWithTag(roomTag))
        {
            if (spawnableGround.name == roomName)
            {
                if (spawnableGround.GetComponent<RoomStates>() != null)
                {
                    RoomStates rStates = spawnableGround.GetComponent<RoomStates>();

                    if (rStates.ReturnRoomState() != "inactive")
                    {
                        rooms.Add(spawnableGround);
                    }
                }
            }
        }
    }

    private void RoomCleared(GameObject room)
    {
        Debug.Log("OnRoomCleared called");
        rooms.Remove(room);

        if (rooms.Count == 0)
        {
            floorCompletedScreen.SetActive(true);
        }
    }

    public void PlayerDeath()
    {
        gameOverScreen.SetActive(true);
    }

    public float ReturnRoomIndex()
    {
        if (isFirstRoom)
        {
            isFirstRoom = false;
            return 0f;
        } else
        {
            return currentRoomIndex;
        }
    }
}
