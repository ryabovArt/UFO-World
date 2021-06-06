using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public static Transform particleGO;
    public static Transform particleGO_2;
    public static Transform renderer;

    public static Effects instance;

    public List<ParticleSystem> ps = new List<ParticleSystem>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    /// <summary>
    /// Эффект ускорения
    /// </summary>
    public void UseForce()
    {
        for (int i = 0; i < 2; i++)
        {
            ps[i].startSpeed = Mathf.Clamp(ps[0].startSpeed, 10, 16);
            var em = ps[i].emission;
            em.rateOverTime = 10;
        }
    }

    /// <summary>
    /// Отключение эффекта ускорения
    /// </summary>
    public void WithoutForce()
    {
        for (int i = 0; i < 2; i++)
        {
            ps[i].startSpeed = Mathf.Clamp(ps[0].startSpeed, 1, 3);
            var em = ps[i].emission;
            em.rateOverTime = 4;
        }
    }
}
