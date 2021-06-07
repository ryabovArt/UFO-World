using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateForce : BaseMoveInput, ICommand
{
    public void Execute()
    {
        force = 2f;
        Effects.instance.WithoutForce();
    }
}
