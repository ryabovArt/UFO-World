using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : EntitiesBehaviour
{
    public PlayerHealth playerHealth;

    private new List<Renderer> renderer = new List<Renderer>();
    private List<Color> defaultColor = new List<Color>();
    [SerializeField] private Color blinkColor;
    private bool isLive = true;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        print(transform.childCount);

        for (int i = 0; i < transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).GetComponent<MeshRenderer>())
            {
                defaultColor.Add(transform.GetChild(i).GetComponent<Renderer>().material.color);
                renderer.Add(transform.GetChild(i).GetComponent<Renderer>());
            }
            
        }
    }

    /// <summary>
    /// Действия при смерти игрока
    /// </summary>
    /// <param name="damage">урон</param>
    public override void SetDamage(float damage)
    {
        if (isLive)
        {
            if (playerHealth.SetDamage(damage))
            {
                foreach (var ren in renderer)
                {
                    ren.material.color = blinkColor;
                }
                StartCoroutine(Blink());
            }
            else
            {
                UFOCrush.current.Crush();
                playerHealth.currentHP = playerHealth.startHP;
            }
        }
    }

    /// <summary>
    /// Мигание при уроне
    /// </summary>
    /// <returns></returns>
    IEnumerator Blink()
    {
        yield return new WaitForSeconds(0.05f);
        for (int i = 0; i < defaultColor.Count; i++)
        {
            renderer[i].material.color = defaultColor[i];
        }
    }
}
