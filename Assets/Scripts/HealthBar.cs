using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public void SetMaxHealth(int MaxHealth)
    {
        healthSlider.maxValue = MaxHealth;
        healthSlider.value = MaxHealth;
    }

    public void SetHealth(int Health) 
    {
        healthSlider.value = Health;
    }

}
