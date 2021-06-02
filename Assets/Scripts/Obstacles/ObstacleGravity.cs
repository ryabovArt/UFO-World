using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGravity : MonoBehaviour
{
    const float gravityConst = 0.15f; // коэффициент гравитации

    public GameObject affector; // притягиваемый объект
    private Rigidbody rb;
    private float distance;
    public bool isGravity = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        SetGravity();
    }

    /// <summary>
    /// Рассчитываем притяжение объектов
    /// </summary>
    private void SetGravity()
    {
        if (affector != null)
        {
            distance = Vector3.Distance(transform.position, affector.transform.position);
            rb.AddForce(((affector.transform.position - transform.position) / distance) *
                (rb.mass * affector.GetComponent<Rigidbody>().mass * gravityConst) / (distance * distance + 1));
        }
    }
}
