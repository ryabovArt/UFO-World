using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Transform startPoint; // начало чанка
    [SerializeField] private Transform endPoint; // конец чанка
    public Transform StartPoint => startPoint;
    public Transform EndPoint => endPoint;
}
