using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupFlight : MonoBehaviour
{
    [Header("Powerup Settings")]
    [SerializeField] float _speedIncreaseAmount = 20;
    [SerializeField] float _powerupDuration = 5;

    [Header("Setup")]
    [SerializeField] GameObject _visualsToDeactivate = null;


    Collider _colliderToDeactivate = null;
    bool _poweredUp = false;

    

   private void Awake()
    {
        _colliderToDeactivate = GetComponent<Collider>();

        EnableObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        FirstPersonPlayer player
            = other.gameObject.GetComponent<FirstPersonPlayer>();
        // if we have a valid player and not already powered up
        if(player != null && _poweredUp == false)
        {
            // start powerup timer. Restart if it's already started
            StartCoroutine(PowerupSequence(player));
        }
    }

    IEnumerator PowerupSequence(FirstPersonPlayer player)
    {
        // set boolean for detecting lockout
        _poweredUp = true;

        ActivatePowerup(player);
        // simulate this object being disabled
        DisableObject();

        // wait for the required duration
        yield return new WaitForSeconds(_powerupDuration);
        // reset
        DeactivatePowerup(player);
        EnableObject();

        // set boolean to release lockout
        _poweredUp = false;
    }

    void ActivatePowerup(FirstPersonPlayer player)
    {
        if(player != null)
        {
            // powerup player
            player.ActivateJetpack();

            player.GetComponent<JetPack>().enabled = true;

            // visuals
            
        }
    }

    void DeactivatePowerup(FirstPersonPlayer player)
    {
        // revert player powerup
        player.DeactivateJetpack();
        player.GetComponent<JetPack>().enabled = false;

        // visuals

    }

    public void DisableObject()
    {
        // disable collider so it can't be retriggered
        _colliderToDeactivate.enabled = false;
        // disable visuals to simulate deactivated
        _visualsToDeactivate.SetActive(false);
    }

    public void EnableObject()
    {
        // enable collider so it can be retriggered
        _colliderToDeactivate.enabled = true;
        //enable visuals again
        _visualsToDeactivate.SetActive(true);
    }
} 
