using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCommunicator : MonoBehaviour
{
    private RoomStates roomStateScript;

    public void GetRoomReferences(RoomStates stateScript)
    {
        roomStateScript = stateScript;
    }

    public void OnDeath()
    {
        //roomStateScript.EnemyDeath(gameObject);
    } 
}
