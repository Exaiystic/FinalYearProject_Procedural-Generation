using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Camera cam;
    [SerializeField] private Transform player;
    [SerializeField] private float threshold;

    private PlayerinputActions playerInputActions;

    private void Awake()
    {
        if (cam == null)
        { cam = Camera.main; }

        if (player == null)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Player");
            player = temp.transform;
        }
    }

    public void Start()
    {
        playerInputActions = new PlayerinputActions();
        playerInputActions.Player.Enable();
    }

    private void Update()
    {
        Vector2 mousePos = playerInputActions.Player.Aiming.ReadValue<Vector2>();
        Vector3 pos = cam.ScreenToWorldPoint(mousePos) / 2f;

        Vector3 targetPos = player.position + pos;

        targetPos.x = Mathf.Clamp(targetPos.x, -threshold + player.position.x, threshold + player.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -threshold + player.position.y, threshold + player.position.y);

        this.transform.position = targetPos;
    }
}
