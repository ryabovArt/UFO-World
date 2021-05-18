using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public static Transform particleGO;
    public static Transform particleGO_2;
    public static Transform renderer;
    public static GameObject forDestroy;

    private void OnTriggerEnter(Collider other)
    {
        if (TryGetComponent(out BombCollisionAction bombCollisionAction))
        {
            bombCollisionAction.BombCollisionActions();
        }
        if (TryGetComponent(out MineCollisionAction mineCollisionAction))
        {
            mineCollisionAction.MineCollisionActions();
        }
    }
}
