using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMagneticObjects : MonoBehaviour
{
    private GameObject ufo;

    private void OnEnable()
    {
        IdentifyMagneticObjects();
    }
    private void OnDisable()
    {
        GetComponent<Rigidbody>().mass = 0;
        FindingObjects.instance.findingObj.Remove(this.gameObject);
    }

    /// <summary>
    /// Назначаем объекты, которые должны притягиваться
    /// </summary>
    private void IdentifyMagneticObjects()
    {
        FindingObjects.instance.findingObj.Add(this.gameObject);
        foreach (var obj in FindingObjects.instance.findingObj)
        {
            if (obj.CompareTag("Player"))
            {
                ufo = obj;
                obj.GetComponent<ObstacleGravity>().affector = this.gameObject;
            }
            if (obj.CompareTag("BlackHole"))
            {
                GetComponent<Rigidbody>().mass = 15000;
                GetComponent<ObstacleGravity>().affector = ufo;
            }
        }
    }
}
