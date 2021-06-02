using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnetization : MonoBehaviour
{
    public Rigidbody rigidbody;

    // фризим позиции, чтобы игрок не съезжал со стартовой платформы

    private void OnTriggerEnter(Collider other)
    {
        rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
    }

    private void OnTriggerExit(Collider other)
    {
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    }
}
