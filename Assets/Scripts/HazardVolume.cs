using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FirstPersonPlayer player
            = other.gameObject.GetComponent<FirstPersonPlayer>();
        // if we found something valid, continue
        if(player != null)
        {
            // do something!
            player.TakeDamage(30);
        }
    }
}
