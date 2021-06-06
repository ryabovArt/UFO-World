using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateForce : BaseMoveInput, ICommand
{
    public void Execute()
    {
        Force = 4f;
        Effects.instance.UseForce();
    }
}
