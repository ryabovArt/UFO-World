using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOCrush : MonoBehaviour
{
    public static UFOCrush current;

    private void Awake()
    {
        current = this;
    }

    public event Action OnCrush;
    public void Crush()
    {
        OnCrush?.Invoke();
    }
}