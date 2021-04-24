using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Transform startPoint; // начало чанка
    [SerializeField] private Transform endPoint; // конец чанка
    public Transform StartPoint => startPoint;
    public Transform EndPoint => endPoint;

    //[SerializeField] private GameObject[] planets;
    //[SerializeField] private Material[] planetMaterial;


    //private void Start()
    //{
    //    foreach (var planet in planets)
    //    {
    //        planet.GetComponent<MeshRenderer>().material = planetMaterial[Random.Range(0, planetMaterial.Length)];
    //    }
    //}
}
