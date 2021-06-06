using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateForce : BaseMoveInput, ICommand
{
    public void Execute()
    {
        Force = 4f;
        Effects.instance.WithoutForce();
    }
}
