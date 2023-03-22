using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Settings - Spawning")]
    [SerializeField] private float spawnCost;
    
    [Header("Settings - Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;

    [Header("Settings - Attack")]
    [SerializeField] private float attackRange;
    [SerializeField] private float damage;
    [SerializeField] private float attackRate;
    [SerializeField] private AttackBase enemyAttackScript;

    [Header("Settings - Target")]
    [SerializeField] private GameObject target;
    [SerializeField] private string detectionTag = "Player";

    private enum State { PUSHING, ATTACKING, WAITING};
    private State currentState;

    private float nextAttack = 0f;

    private void Awake()
    {
        if (target == null)
        { target = GameObject.FindGameObjectWithTag(detectionTag); }
        else if (target.tag != detectionTag)
        { target = GameObject.FindGameObjectWithTag(detectionTag); }

        if (enemyAttackScript == null)
        { enemyAttackScript = GetComponent<AttackBase>(); }

        if (rb == null)
        { rb = GetComponent<Rigidbody2D>(); }
    }

    // Update is called once per frame
    void Update()
    {
        //Determining what state the enemy should be in
        DecideState();
        
        //Actions based off state
        switch (currentState)
        {
            case State.ATTACKING:
                AttackingState();
                break;

            case State.PUSHING:
                PushingState();
                break;
        }

        //Counting down until the next time the weapon can attack
        if (nextAttack > 0f) { nextAttack -= Time.deltaTime; }

        //Sprite orientation
        SpriteOrientation();
    }

    protected void DecideState()
    {
        if (target != null)
        {
            Vector2 targetPos = target.transform.position;
            Vector2 selfPos = transform.position;
            float distance = Vector2.Distance(selfPos, targetPos);

            if (distance < attackRange)
            {
                AttackingState();
                currentState = State.ATTACKING;
            } else
            {
                PushingState();
                currentState = State.PUSHING;
            }
        } else
        {
            currentState = State.WAITING;
        }
    }

    private void FixedUpdate()
    {
        if (currentState == State.PUSHING)
        { rb.MovePosition(Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime)); }
    }

    protected void PushingState()
    { 
        //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);  //  OLD - allowed enemies to move through walls
    }

    protected void AttackingState()
    {
        if (nextAttack <= 0f)
        {
            if (enemyAttackScript != null)
            { enemyAttackScript.PrimaryAttack(damage); }

            nextAttack = attackRate;
        }
    }

    //Ideally would be part of the sprite orientation script - but that script is currently only unusable due to it working off player inputs
    private void SpriteOrientation()
    {
        Vector3 relativeDirection = transform.InverseTransformDirection(target.transform.position);
        if (relativeDirection.x < 0f)
        { transform.localScale = new Vector3 (-1f, 1f, 1f); } 
        else
        { transform.localScale = new Vector3 (1f, 1f, 1f); }
    }

    public GameObject ReturnTarget()
    {
        return target;
    }

    public float ReturnCost()
    {
        return spawnCost;
    }
}
