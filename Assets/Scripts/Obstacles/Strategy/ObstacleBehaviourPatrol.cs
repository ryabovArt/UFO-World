using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviourPatrol : IObstacleFields
{
    public override void Enter()
    {
        Debug.Log("Enter Patrol");
    }

    public override void Exit()
    {
        Debug.Log("Exit Patrol");
    }

    public override void Update()
    {
        Debug.Log("Update Patrol");
    }
}
