using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] Camera cameraController;
    [SerializeField] Transform rayOrigin;
    [SerializeField] float shootDistance = 10f;
    [SerializeField] GameObject visualFeedbackObject; // hitpoint light
    [SerializeField] int weaponDamage = 20;
    [SerializeField] LayerMask hitLayers;

    RaycastHit objectHit;   // store info about our raycast hit


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
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

            if (objectHit.transform.tag == "Enemy")
            {
                Debug.Log("DEAL DAMAGE");
                // Visual Feedback
                visualFeedbackObject.transform.position = objectHit.point;
                // If enemy is hit, apply damage
                EnemyShooter enemyShooter = objectHit.transform.gameObject.GetComponent<EnemyShooter>();
                if (enemyShooter != null)
                {
                    enemyShooter.TakeDamage(weaponDamage);
                }
            }
        }
        else
        {
            Debug.Log("Miss");
        }
    }
}
