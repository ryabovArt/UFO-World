using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindingObjects : MonoBehaviour
{
    public static FindingObjects instance = null;

    public List<GameObject> findingObj = new List<GameObject>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
}
