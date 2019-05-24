using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthBarSystem  
{
    public int healthAmount;
    private int healthAmountMax;
    public event EventHandler OnHealthChange;


    public HealthBarSystem()
    {
        healthAmountMax = 100;
        healthAmount = healthAmountMax;
    }

    public float GetHealthNormalized()
    {
        return (float)healthAmount / healthAmountMax;
    }
    public void HealthDamage(int damageAmount)
    {
        healthAmount -= damageAmount;
        if (OnHealthChange != null) OnHealthChange(this, EventArgs.Empty);
        if(healthAmount <= 0)
        {
            Debug.Log("you are dead");
        }
    }
}
