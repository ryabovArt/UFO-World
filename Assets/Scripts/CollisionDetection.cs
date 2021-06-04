using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public static Transform particleGO;
    public static Transform particleGO_2;
    public static Transform renderer;
    public static GameObject forDestroy;

    /// <summary>
    /// Проверяем столкновение с любым объектом
    /// </summary>
    /// <param name="other">объект</param>
    private void OnTriggerEnter(Collider other)
    {
        if (TryGetComponent(out BombCollisionAction bombCollisionAction))
        {
            bombCollisionAction.BombCollisionActions();
            print("CollisionDetection");
        }
        if (TryGetComponent(out MineCollisionAction mineCollisionAction))
        {
            mineCollisionAction.MineCollisionActions();
            print("CollisionDetection");
        }
    }
}
