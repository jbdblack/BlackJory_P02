using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooter : MonoBehaviour
{
    public int _enemyHealth = 100;
    public LayerMask aggroLayerMask;
    [SerializeField] GameObject bullet;

    private NavMeshAgent navAgent;
    private Collider[] withinAggroColliders;
    private FirstPersonPlayer player;

    float fireRate;
    float nextFire;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();

        fireRate = 4f;
        nextFire = Time.time;
    }

    void FixedUpdate()
    {
        withinAggroColliders = Physics.OverlapSphere(transform.position, 10, aggroLayerMask);
        if(withinAggroColliders.Length > 0)
        {
            Debug.Log("Found player");
            ChasePlayer(withinAggroColliders[0].GetComponent<FirstPersonPlayer>());
        }

        CheckIfTimeToFire();
    }

    void Update()
    {
        //CheckIfTimeToFire();
    }

    public void TakeDamage(int _damageAmount)
    {
        _enemyHealth -= _damageAmount;
        Debug.Log("Enemy has taken damage!");
        Debug.Log(_enemyHealth + " health remaining");
        if (_enemyHealth <= 0)
        {
            _enemyHealth = 0;
            DestroyEnemy();
        }

    }

    void ChasePlayer(FirstPersonPlayer player)
    {
        this.player = player;
        navAgent.SetDestination(player.transform.position);
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, this.transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
