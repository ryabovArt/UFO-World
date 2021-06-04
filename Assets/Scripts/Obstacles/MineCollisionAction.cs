using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCollisionAction : MonoBehaviour
{
    /// <summary>
    /// Взрыв мины
    /// </summary>
    public void MineCollisionActions()
    {
        CollisionDetection.renderer = null;
        CollisionDetection.particleGO = null;
        CollisionDetection.particleGO = transform.GetChild(1);
        CollisionDetection.particleGO.GetComponent<ParticleSystem>().Play();
        CollisionDetection.forDestroy = gameObject;
        CollisionDetection.renderer = transform.GetChild(0);
        CollisionDetection.renderer.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(EnableMesh());
    }

    /// <summary>
    /// Уничтожение мины
    /// </summary>
    /// <returns></returns>
    IEnumerator EnableMesh()
    {
        yield return new WaitForSeconds(1f);
        Destroy(CollisionDetection.forDestroy);
        CollisionDetection.forDestroy = null;
    }
}
