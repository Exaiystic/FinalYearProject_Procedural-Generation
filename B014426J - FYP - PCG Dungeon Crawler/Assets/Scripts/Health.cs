using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Health : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool playerHealth = false;
    [SerializeField] private float startHealth = 100;
    [SerializeField] private float invulnerabilityTime = 1f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color hitColor;

    [Header("Player Only")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CameraShake camShake;
    [SerializeField] private float shakeDuration = 0.1f;
    [SerializeField] private float shakeMagnitude = 0.15f;

    private Color spriteDefaultColor;

    //[Header("References - Enemies Only")]
    //[SerializeField] private RoomCommunicator roomCommunicator;

    private HealthDisplay healthDisplay;
    private float currentHealth;

    private float canNextTakeDamage = 0f;

    private void Awake()
    {
        if (playerHealth)
        {
            //Not being used anywhere?
            /*
            if (gameManager == null)
            {
                GameObject manager = GameObject.Find("GameManager");
                gameManager = manager.GetComponent<GameManager>();
            }
            */
        }

        if (spriteRenderer == null)
            { spriteRenderer = GetComponent<SpriteRenderer>(); }

        if (camShake == null)
            { camShake = Camera.main.GetComponent<CameraShake>(); }

        ResetHealth();
    }

    private void Start()
    {
        CustomEventSystem.current.onNewDungeonEvent += Reset;

        spriteDefaultColor = spriteRenderer.color;
    }

    private void Update()
    {
        if (canNextTakeDamage > 0f)
        { 
            canNextTakeDamage -= Time.deltaTime; 
        } else
        {
            spriteRenderer.color = spriteDefaultColor;
        }
    }

    public void TakeDamage(float damage)
    {
        if (canNextTakeDamage <= 0f)
        {
            currentHealth -= damage;
            
            //VFX
            spriteRenderer.color = hitColor; 
            if (camShake != null)
            {
                StartCoroutine(camShake.ShakeCamera(shakeDuration, shakeMagnitude));
            }

            if (currentHealth <= 0)
            {
                Death();
                if (healthDisplay != null) { healthDisplay.UpdateHealth(0); }
            }
            else if (healthDisplay != null) { healthDisplay.UpdateHealth(currentHealth); }
        }

        canNextTakeDamage = invulnerabilityTime;
    }

    private void Death()
    {
        //Debug.Log("You Dead");

        if (!playerHealth)
        {
            //roomCommunicator.OnDeath();
            CustomEventSystem.current.EnemyDeath(gameObject);
            Destroy(gameObject);
        } else
        {
            CustomEventSystem.current.PlayerDeath();
            //gameManager.PlayerDeath(); 
        }
    }

    private void Reset()
    {
        if (playerHealth)
        {
            ResetHealth();

            transform.position = Vector3.zero;
        }
    }

    public void GetAccessingHealthDisplay(HealthDisplay accessor)
    {
        healthDisplay = accessor;
    }

    //Bodged - as the health is only updated once damage is taken we need a seperate method to get the health at the start of play
    public float ReturnHealth()
    {
        return startHealth;
    }

    public void ResetHealth()
    {
        currentHealth = startHealth;

        if (healthDisplay != null)
        { healthDisplay.UpdateHealth(currentHealth); }
    }
}
