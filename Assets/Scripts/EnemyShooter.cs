using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooter : MonoBehaviour
{
    public int _enemyHealth = 100;
    public LayerMask aggroLayerMask;

    private NavMeshAgent navAgent;
    private Collider[] withinAggroColliders;
    private FirstPersonPlayer player;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        withinAggroColliders = Physics.OverlapSphere(transform.position, 10, aggroLayerMask);
        if(withinAggroColliders.Length > 0)
        {
            Debug.Log("Found player");
            ChasePlayer(withinAggroColliders[0].GetComponent<FirstPersonPlayer>());
        }
    }

    public void TakeDamage(int _damageAmount)
    {
        _enemyHealth -= _damageAmount;
        Debug.Log("Enemy has taken damage!");
        Debug.Log(_enemyHealth + " health remaining");
        if (_enemyHealth <= 0)
        {
            _enemyHealth = 0;
        }

    }

    void ChasePlayer(FirstPersonPlayer player)
    {
        this.player = player;
        navAgent.SetDestination(player.transform.position);
    }
}
