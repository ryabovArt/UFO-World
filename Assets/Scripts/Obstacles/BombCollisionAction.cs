using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollisionAction : MonoBehaviour
{
    public void BombCollisionActions()
    {
        print("collis");
        CollisionDetection.renderer = null;
        CollisionDetection.particleGO = null;
        CollisionDetection.particleGO_2 = null;
        CollisionDetection.particleGO = transform.GetChild(2);
        CollisionDetection.particleGO_2 = transform.GetChild(1);
        CollisionDetection.particleGO.GetComponent<ParticleSystem>().Play();
        CollisionDetection.particleGO_2.GetComponent<ParticleSystem>().Stop();
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
