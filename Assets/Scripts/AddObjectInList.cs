using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObjectInList : MonoBehaviour
{
    private void OnEnable()
    {
        FindingObjects.instance.findingObj.Add(this.gameObject);
    }
    private void OnDisable()
    {
        FindingObjects.instance.findingObj.Remove(this.gameObject);
    }
}