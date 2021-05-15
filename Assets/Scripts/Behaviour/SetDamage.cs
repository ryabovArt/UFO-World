using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDamage : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerBehaviour collisionBehaviour = collision.gameObject.GetComponent<PlayerBehaviour>();
        if (collisionBehaviour) collisionBehaviour.SetDamage(damage);
    }
}
