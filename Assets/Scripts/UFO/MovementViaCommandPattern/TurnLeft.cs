using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeft : BaseMoveInput, ICommand
{
    public void Execute()
    {
        LeftEngineRigidbody.AddRelativeForce(Vector3.up * Speed * changeTurnSpeed);
    }
}
