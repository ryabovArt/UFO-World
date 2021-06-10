using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFOMovement : BaseMoveInput
{
    [SerializeField] private TurnRight turnRight;
    [SerializeField] private TurnLeft turnLeft;
    [SerializeField] private MoveUp moveUp;
    [SerializeField] private MoveDown moveDown;
    [SerializeField] private ActivateForce activateForce;
    [SerializeField] private DeactivateForce deactivateForce;

    private ICommand turnRightCommand;
    private ICommand turnLeftCommand;
    private ICommand moveUpCommand;
    private ICommand moveDownCommand;
    private ICommand activateForceCommand;
    private ICommand deactivateForceCommand;

    private void Awake()
    {
        turnRightCommand = turnRight;
        turnLeftCommand = turnLeft;
        moveUpCommand = moveUp;
        moveDownCommand = moveDown;
        activateForceCommand = activateForce;
        deactivateForceCommand = deactivateForce;
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        PlayerController();

        AddForce();
    }

    /// <summary>
    /// Управление персонажем
    /// </summary>
    private void PlayerController()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        //float vertical = joystick_vertical.Vertical;
        //float horizontal = joystick_vertical.Horizontal;

        if (horizontal > 0)
        {
            turnLeftCommand.Execute();
        }
        else if (horizontal < 0)
        {
            turnRightCommand.Execute();
        }
        else if (vertical > 0)
        {
            moveUpCommand.Execute();
        }
        else if (vertical < 0)
        {
            moveDownCommand.Execute();
        }
        else if (horizontal == 0 && vertical == 0)
        {
            leftSlider.fillAmount -= sliderStep * Time.deltaTime;
            rightSlider.fillAmount -= sliderStep * Time.deltaTime;
        }
        
    }

    /// <summary>
    /// Ускорение
    /// </summary>
    [System.Obsolete]
    private void AddForce()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //activateForceCommand.Execute();
            //print(Force);
            Force = 8f;
            Effects.instance.UseForce();
        }
        else
        {
            //deactivateForceCommand.Execute();
            //print(Force);
            Force = 2f;
            Effects.instance.WithoutForce();
        }
    }

    ///// <summary>
    ///// Ускорение
    ///// </summary>
    //public void TurnOnForce()
    //{
    //    force = 5f;
    //    Effects.instance.UseForce();
    //}

    ///// <summary>
    ///// Отмена ускорения
    ///// </summary>
    //public void TurnOffForce()
    //{
    //    force = 2f;
    //    Effects.instance.WithoutForce();
    //}

    //public void TurnLeft()
    //{
    //    print("left");
    //    rightEngineRigidbody.AddRelativeForce(Vector3.up * speed * changeTurnSpeed);
    //}

    //public void TurnRight()
    //{

    //    leftEngineRigidbody.AddRelativeForce(Vector3.up * speed * changeTurnSpeed);
    //}

    //public void MoveUp()
    //{
    //    leftEngineRigidbody.AddRelativeForce(Vector3.up * speed * force);
    //    rightEngineRigidbody.AddRelativeForce(Vector3.up * speed * force);
    //    print("UP");
    //}

    //public void MoveDown()
    //{
    //    leftEngineRigidbody.AddRelativeForce(Vector3.up * -speed * force);
    //    rightEngineRigidbody.AddRelativeForce(Vector3.up * -speed * force);
    //}
}
