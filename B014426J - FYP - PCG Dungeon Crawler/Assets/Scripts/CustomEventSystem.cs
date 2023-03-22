using System;
using UnityEngine;

public class CustomEventSystem : MonoBehaviour
{
    public static CustomEventSystem current;

    private void Awake()
    {
        current = this;
    }

    public event Action<GameObject> onRoomClearedEvent;
    public void RoomCleared(GameObject room)
    {
        if (onRoomClearedEvent != null)
        {
            onRoomClearedEvent(room);
        }
    }

    public event Action<GameObject> onEnemyDeathEvent;
    public void EnemyDeath(GameObject enemy)
    {
        if (onEnemyDeathEvent != null)
        {
            onEnemyDeathEvent(enemy);
        }
    }

    public event Action onNewDungeonEvent;
    public void NewDungeon()
    {
        if (onEnemyDeathEvent != null)
        {
            onNewDungeonEvent();
        }
    }

    public event Action onPlayerDeathEvent;
    public void PlayerDeath()
    {
        if (onPlayerDeathEvent != null)
        {
            onPlayerDeathEvent();
        }
    }
}
