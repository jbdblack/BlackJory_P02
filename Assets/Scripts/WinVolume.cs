using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinVolume : MonoBehaviour
{
    [SerializeField] GameObject youWinText;
    private AudioSource source;
    [SerializeField] AudioClip victory;

    private void OnTriggerEnter(Collider other)
    {
        FirstPersonPlayer player
            = other.gameObject.GetComponent<FirstPersonPlayer>();
        // if we found something valid, continue
        if (player != null)
        {
            // do something!
            youWinText.SetActive(true);
            source.PlayOneShot(victory, 1f);
        }
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void YouWin()
    {
        youWinText.SetActive(true);
    }
}
