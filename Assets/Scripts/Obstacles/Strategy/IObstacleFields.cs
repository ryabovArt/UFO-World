using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IObstacleFields : IObstacleBehaviour
{
    public Transform[] PatrolPoint => patrolPoint;

    public Transform PlayerTransform => playerTransform;

    public float Speed { get => speed; set => speed = value; }
    public float StartSpeed { get => startSpeed; set => startSpeed = value; }
    public float PursuitSpeed { get => pursuitSpeed; set => pursuitSpeed = value; }
    public float StopDistance { get => stopDistance; set => stopDistance = value; }
    public int RandomPiont { get => randomPiont; set => randomPiont = value; }

    public float StartWaitTime => startWaitTime;

    public float WaitTime { get => waitTime; set => waitTime = value; }


    [SerializeField] private Transform[] patrolPoint; // конечные точки патрулирования
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float speed;
    private float startSpeed;
    [SerializeField] private float pursuitSpeed;
    [SerializeField] private float stopDistance;

    private int randomPiont;

    [SerializeField] private float startWaitTime;
    private float waitTime;

    public abstract void Enter();

    public abstract void Exit();

    public abstract void Update();
}
