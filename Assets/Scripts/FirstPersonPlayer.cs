using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class FirstPersonPlayer : MonoBehaviour
{

    [SerializeField] Text _currentHealthTextView;
    [SerializeField] AudioClip damageSound;

    private AudioSource source;

    public float _playerHealth = 100f;

    public bool jetpack = false;

    UIManager uiManager;
    
    //potentially move this functionality out of the player script
    [SerializeField] GameObject youLoseText;

    Rigidbody _rb = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        // fill our references
        uiManager = FindObjectOfType<UIManager>();
        source = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if(_playerHealth <= 0f)
        {
            Kill();
        }
    }


    public void TakeDamage(int _damageAmount)
    {
        _playerHealth -= _damageAmount;
        Debug.Log("Player has taken damage!");
        // Play sound effect
        source.PlayOneShot(damageSound, 1f);

        if (_playerHealth <= 0)
        {
            _playerHealth = 0;
        }
        // update Health Text
        _currentHealthTextView.text =
            "Health: " + _playerHealth.ToString();
        // update the Health Slider
        uiManager.UpdateHealthSlider();

    }

    public void Kill()
    {
        Debug.Log("Player has been killed!");
        //this.gameObject.SetActive(false);
        YouLose();
        
    }

    public void YouLose()
    {
        youLoseText.SetActive(true);
    }

    public void ActivateJetpack()
    {
        jetpack = true;
    }

    public void DeactivateJetpack()
    {
        jetpack = false;
    }
}
