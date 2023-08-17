using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy
    : MonoBehaviour, IDamageable
{
    public NavMeshAgent Agent { get => agent; }
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    public GameObject gun;

    [Header("Characteristics")]
    public float health = 100f;
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;

    [Header("Navigation")]
    public Path path;

    [Header("State")] //debugging
    [SerializeField]
    private string currentState;

    [Header("Player reference")]
    public GameObject player;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
    }

    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }

    public bool CanSeePlayer()
    {
        if (player == null) return false;

        if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
        {
            Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
            float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);

            if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
            {
                Ray ray = new(transform.position + (Vector3.up * eyeHeight), targetDirection);
                
                if (Physics.Raycast(ray, out var hitInfo, sightDistance))
                {
                    if (hitInfo.transform.gameObject == player) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }
}
