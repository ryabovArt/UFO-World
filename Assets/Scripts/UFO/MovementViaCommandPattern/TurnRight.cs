using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRight : BaseMoveInput, ICommand
{
    public void Execute()
    {
        maxForce = Vector3.up * Speed * changeTurnSpeed;

        RightEngineRigidbody.AddRelativeForce(maxForce);
        leftSlider.fillAmount += sliderStep * Time.deltaTime;
        rightSlider.fillAmount -= sliderStep * Time.deltaTime;
    }
}
