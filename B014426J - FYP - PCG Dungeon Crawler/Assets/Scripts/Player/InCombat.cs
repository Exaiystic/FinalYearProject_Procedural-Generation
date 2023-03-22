using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCombat : MonoBehaviour
{
    [SerializeField] private GameObject combatIndicator;

    private bool inCombat;
    private Collider2D roomCollider;

    private void Update()
    {
        if (roomCollider != null)
            { UpdateRoomStatus(); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SpawnableGround")
        {
            roomCollider = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SpawnableGround")
        {
            roomCollider = collision;
        }
    }

    private void UpdateRoomStatus()
    {
        RoomStates rStates = roomCollider.gameObject.GetComponent<RoomStates>();
        if (rStates != null)
        {
            if (rStates.ReturnRoomState() == "combat")
            {
                combatIndicator.SetActive(true);
                inCombat = true;
            } else
            {
                combatIndicator.SetActive(false);
                inCombat = false;
            }
        }
    }

    public bool IsInCombat()
    {
        return inCombat;
    }
}
