using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    

    [SerializeField] float minSpeed = 7f;
    [SerializeField] float maxSpeed = 15f;

    [SerializeField] int minDamage = 5;
    [SerializeField] int maxDamage = 15;

    

    Rigidbody rb;

    FirstPersonPlayer target;
    Vector3 moveDirection;
    



    // Start is called before the first frame update
    void Start()
    {
        float moveSpeed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindObjectOfType<FirstPersonPlayer>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        Destroy(gameObject, 6f);
    }

    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("FirstPersonPlayer"))
        {
            Debug.Log("Hit!");
            target.TakeDamage(30);
            Destroy(gameObject);
        }

    }*/

    private void OnTriggerEnter(Collider other)
    {
        FirstPersonPlayer player
            = other.gameObject.GetComponent<FirstPersonPlayer>();
        // if we found something valid, continue
        if (player != null)
        {
            // do something!
            int damageAmount = Random.Range(minDamage, maxDamage);
            Debug.Log("Hit the player!");
            player.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }


}
