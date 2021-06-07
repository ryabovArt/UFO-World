using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : BaseMoveInput, ICommand
{
    public void Execute()
    {
        maxForce = Vector3.up * -Speed * Force;

        LeftEngineRigidbody.AddRelativeForce(maxForce);
        RightEngineRigidbody.AddRelativeForce(maxForce);

        leftSlider.fillAmount -= sliderStep * Time.deltaTime;
        rightSlider.fillAmount -= sliderStep * Time.deltaTime;
    }
}
