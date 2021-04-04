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
    private AudioSource source;
    [SerializeField] AudioClip fireBullet;


    [SerializeField] float fireRate = 2f;
    float nextFire;

    bool _foundPlayer = false;

    //[SerializeField] GameObject levelController;

    public GameObject levelController;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();

        //fireRate = 2f;
        nextFire = Time.time;

        source = GetComponent<AudioSource>();

        levelController = GameObject.Find("LevelController");
    }

    void FixedUpdate()
    {
        withinAggroColliders = Physics.OverlapSphere(transform.position, 20, aggroLayerMask);
        if(withinAggroColliders.Length > 0)
        {
            Debug.Log("Found player");
            ChasePlayer(withinAggroColliders[0].GetComponent<FirstPersonPlayer>());
            _foundPlayer = true;
        }
        else
        {
            _foundPlayer = false;
        }

        if (_foundPlayer == true)
        {
            CheckIfTimeToFire();
        }
        
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
            // Play sound effect
            source.PlayOneShot(fireBullet, 1f);
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
        levelController.GetComponent<Level01Controller>().IncreaseScore(5);

    }
}
