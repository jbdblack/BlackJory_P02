using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Slider healthSlider;
    
    public FirstPersonPlayer playerHealth;
    

    public void UpdateHealthSlider()
    {
        // set the slider value equal to the health
        healthSlider.value = playerHealth._playerHealth;
    }

    
}
