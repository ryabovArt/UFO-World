using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMoveInput : MonoBehaviour
{
    // инкапсулируем поля
    public Rigidbody LeftEngineRigidbody => leftEngineRigidbody;
    public Rigidbody RightEngineRigidbody => rightEngineRigidbody;
    public float Speed => speed;
    public float ChangeTurnSpeedCoef => changeTurnSpeedCoef;
    public float Force { get { return force; } set { force = value; } }


    [SerializeField] private Rigidbody leftEngineRigidbody;
    [SerializeField] private Rigidbody rightEngineRigidbody;

    [SerializeField] private float speed;
    [SerializeField] private float changeTurnSpeedCoef;

    [SerializeField] private float force;
    protected float changeTurnSpeed;

    void Start()
    {
        changeTurnSpeed = speed * changeTurnSpeedCoef;
        force = 2;
        FindingObjects.instance.findingObj.Add(gameObject);
    }
}
