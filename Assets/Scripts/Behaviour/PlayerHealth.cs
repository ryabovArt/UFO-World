using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public float startHP = 100;
    public float currentHP;

    private void Start()
    {
        currentHP = startHP;
        print(currentHP);
    }

    public override bool SetDamage(float damage)
    {
        currentHP -= damage;
        print(currentHP);

        if (currentHP > 0) return true;
        else
        {
            return false;
        }
    }
}
