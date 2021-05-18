using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCollisionAction : MonoBehaviour
{
    public void MineCollisionActions()
    {
        Effects.instance.DestroyBlackHole();
        CollisionDetection.renderer = null;
        CollisionDetection.particleGO = null;
        CollisionDetection.particleGO = transform.GetChild(1);
        CollisionDetection.particleGO.GetComponent<ParticleSystem>().Play();
        CollisionDetection.forDestroy = gameObject;
        CollisionDetection.renderer = transform.GetChild(0);
        CollisionDetection.renderer.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(EnableMesh());
    }

    IEnumerator EnableMesh()
    {
        yield return new WaitForSeconds(1f);
        Destroy(CollisionDetection.forDestroy);
        CollisionDetection.forDestroy = null;
    }
}
