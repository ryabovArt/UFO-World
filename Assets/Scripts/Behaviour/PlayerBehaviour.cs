using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : EntitiesBehaviour
{
    public PlayerHealth playerHealth;

    private bool isLive = true;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    public override void SetDamage(float damage)
    {
        if (isLive)
        {
            if (playerHealth.SetDamage(damage))
            {

            }
            else
            {
                UFOCrush.current.Crush();
                playerHealth.currentHP = playerHealth.startHP;
                print("death");
            }
        }
    }
}
