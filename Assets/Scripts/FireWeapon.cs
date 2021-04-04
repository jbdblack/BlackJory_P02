using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] Camera cameraController;
    [SerializeField] Transform rayOrigin;
    [SerializeField] float shootDistance = 10f;
    [SerializeField] ParticleSystem visualFeedbackObject; // hitpoint light
    [SerializeField] int weaponDamage = 50;
    [SerializeField] LayerMask hitLayers;

    [SerializeField] AudioClip impact;
    [SerializeField] AudioClip fireWeapon;

    private AudioSource source;
    

    RaycastHit objectHit;   // store info about our raycast hit

    void Start()
    {
        source = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
            // Play sound effect
            source.PlayOneShot(fireWeapon, 0.7f);
        }
    }

    // fire the weapon using a raycast
    void Shoot()
    {
        // calculate direction to shoot the ray
        Vector3 rayDirection = cameraController.transform.forward;
        // cast a debug ray
        Debug.DrawRay(rayOrigin.position, rayDirection * shootDistance, Color.blue, 1f);
        // fire the raycast
        if(Physics.Raycast(rayOrigin.position, rayDirection, out objectHit, shootDistance, hitLayers))
        {
            // Print name of object that was hit
            Debug.Log("You HIT the " + objectHit.transform.name);
            ImpactEffect();

            if (objectHit.transform.tag == "Enemy")
            {
                Debug.Log("DEAL DAMAGE");
                // Visual Feedback
                //visualFeedbackObject.transform.position = objectHit.point;
                ImpactEffect();
                
                // If enemy is hit, apply damage & play sound effect?
                EnemyShooter enemyShooter = objectHit.transform.gameObject.GetComponent<EnemyShooter>();
                if (enemyShooter != null)
                {
                    enemyShooter.TakeDamage(weaponDamage);
                    source.PlayOneShot(impact, 1f);
                }
            }
        }
        else
        {
            Debug.Log("Miss");
            
        }
        
    }

    void ImpactEffect()
    {
        Instantiate(visualFeedbackObject, objectHit.point, Quaternion.identity);
        visualFeedbackObject.Play();
    }
}
