using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacleBehaviour
{
    Transform[] PatrolPoint { get; } // конечные точки патрулирования
    Transform PlayerTransform { get; }

    float Speed { get; set; }
    float StartSpeed { get; set; }
    float PursuitSpeed { get; set; }
    float StopDistance { get; set; }

    int RandomPiont { get; set; }

    float StartWaitTime { get; }
    float WaitTime { get; set; }

    void Enter();
    void Exit();
    void Update();
}
