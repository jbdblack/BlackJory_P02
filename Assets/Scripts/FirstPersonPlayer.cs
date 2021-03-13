using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class FirstPersonPlayer : MonoBehaviour
{

    [SerializeField] Text _currentHealthTextView;

    public float _playerHealth = 100f;


    Rigidbody _rb = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        if(_playerHealth <= 0f)
        {
            Kill();
        }
    }


    public void TakeDamage()
    {
        _playerHealth -= 30f;
        Debug.Log("Player has taken damage!");
        _currentHealthTextView.text =
            "Health: " + _playerHealth.ToString();
    }

    public void Kill()
    {
        Debug.Log("Player has been killed!");
        //this.gameObject.SetActive(false);
        
    }
}
