using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRight : BaseMoveInput, ICommand
{
    public void Execute()
    {
        RightEngineRigidbody.AddRelativeForce(Vector3.up * Speed * changeTurnSpeed);
    }
}
