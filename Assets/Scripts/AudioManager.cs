using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;

    AudioSource _audioSource;

    [SerializeField] AudioClip _startingSong;
    //[SerializeField] AudioClip _fireBlaster;

    private void Awake()
    {
        #region Singleton Pattern (Simple)
        if(Instance == null)
        {
            // doesn't exist yet, this is now our singleton!
            Instance = this;
            DontDestroyOnLoad(gameObject);
            // fill references
            _audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }

    public void PlaySong(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void PlayEffect(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    void Start()
    {
        // play starting song on menu start
        if (_startingSong != null)
        {
            AudioManager.Instance.PlaySong(_startingSong);
        }
    }
}
