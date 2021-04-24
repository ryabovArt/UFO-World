using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public static Effects instance;

    public List<ParticleSystem> ps = new List<ParticleSystem>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    [System.Obsolete]
    public void UseForce()
    {
        for (int i = 0; i < 2; i++)
        {
            ps[i].startSpeed = Mathf.Clamp(ps[0].startSpeed, 10, 16);
            var em = ps[i].emission;
            em.rateOverTime = 10;
        }
    }

    [System.Obsolete]
    public void WithoutForce()
    {
        for (int i = 0; i < 2; i++)
        {
            ps[i].startSpeed = Mathf.Clamp(ps[0].startSpeed, 1, 3);
            var em = ps[i].emission;
            em.rateOverTime = 4;
        }
    }

    public void DestroyBomb()
    {
        //ps.Add(UFOCheckTrigger.particleGO.GetComponent<ParticleSystem>());
        //ps.Add(UFOCheckTrigger.particleGO_2.GetComponent<ParticleSystem>());
        //ps[3].Play();
        //ps[4].Stop();
        Debug.Log(UFOCheckTrigger.particleGO.transform.position);
        Debug.Log("DestroyBomb");
        //StartCoroutine(BombDestroy());
    }
    IEnumerator BombDestroy()
    {
        yield return new WaitForSeconds(2f);
        ps[3].Stop();
        ps[4].Play();
        UFOCheckTrigger.renderer.GetComponent<MeshRenderer>().enabled = true;
    }

    public void DestroyBlackHole()
    {
        Debug.Log("DestroyBlackHole");
    }
}
