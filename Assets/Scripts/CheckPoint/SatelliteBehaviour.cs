using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float rotationSpeed;

    void Update()
    {
        RotatingAroundPlanet();
    }

    /// <summary>
    /// Врвщение вокруг планеты
    /// </summary>
    private void RotatingAroundPlanet()
    {
        transform.RotateAround(target.transform.position, -Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
