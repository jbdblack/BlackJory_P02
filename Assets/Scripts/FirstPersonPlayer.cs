using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class FirstPersonPlayer : MonoBehaviour
{

    [SerializeField] Text _currentHealthTextView;

    public float _playerHealth = 100f;

    UIManager uiManager;
    
    //potentially move this functionality out of the player script
    [SerializeField] GameObject youLoseText;

    Rigidbody _rb = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        // fill our references
        uiManager = FindObjectOfType<UIManager>();
        
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
        if(_playerHealth <= 0)
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
}
