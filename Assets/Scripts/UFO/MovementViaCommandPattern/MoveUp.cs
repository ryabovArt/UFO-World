﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : BaseMoveInput, ICommand
{
    public void Execute()
    {
        LeftEngineRigidbody.AddRelativeForce(Vector3.up * Speed * Force);
        RightEngineRigidbody.AddRelativeForce(Vector3.up * Speed * Force);
    }
}
