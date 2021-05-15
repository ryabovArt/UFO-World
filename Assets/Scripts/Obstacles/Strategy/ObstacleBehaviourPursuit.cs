using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviourPursuit : IObstacleFields
{
    public override void Enter()
    {
        Debug.Log("Enter Pursuit");
    }

    public override void Exit()
    {
        Debug.Log("Exit Pursuit");
    }

    public override void Update()
    {
        Debug.Log("Update Pursuit");
    }
}
