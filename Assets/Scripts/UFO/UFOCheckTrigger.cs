using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOCheckTrigger : MonoBehaviour
{
    public static Transform particleGO;
    public static Transform particleGO_2;
    public static Transform renderer;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Untagged"))
        {
            UFOCrush.current.Crush();
        }
        if (other.CompareTag("BlackHole"))
        {
            Effects.instance.DestroyBlackHole();
        }
        if (other.CompareTag("Bomb"))
        {
            renderer = null;
            particleGO = null;
            particleGO_2 = null;
            particleGO = other.transform.GetChild(2);
            particleGO_2 = other.transform.GetChild(1);
            particleGO.GetComponent<ParticleSystem>().Play();
            particleGO_2.GetComponent<ParticleSystem>().Stop();
            Effects.instance.DestroyBomb();
            renderer = other.transform.GetChild(0);
            renderer.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(EnableMesh());
        }
        if (other.CompareTag("Mine"))
        {
            Effects.instance.DestroyBlackHole();
            renderer = null;
            particleGO = null;
            particleGO = other.transform.GetChild(1);
            particleGO.GetComponent<ParticleSystem>().Play();
            Effects.instance.DestroyBomb();
            renderer = other.transform.GetChild(0);
            renderer.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(EnableMesh());
        }
    }

    IEnumerator EnableMesh()
    {
        yield return new WaitForSeconds(2f);
        renderer.GetComponent<MeshRenderer>().enabled = true;
        particleGO.GetComponent<ParticleSystem>().Stop();
        if (particleGO_2 != null)
            particleGO_2.GetComponent<ParticleSystem>().Play();
    }
}
