using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviourGoBack : IObstacleFields
{
    public override void Enter()
    {
        Debug.Log("Enter GoBack");
    }

    public override void Exit()
    {
        Debug.Log("Exit GoBack");
    }

    public override void Update()
    {
        Debug.Log("Update GoBack");
    }
}
