using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick_vertical;
    [SerializeField] private Joystick joystick_horizontal;

    [SerializeField] private Rigidbody leftEngineRigidbody;
    [SerializeField] private Rigidbody rightEngineRigidbody;

    [SerializeField] private float speed;
    [SerializeField] private float changeTurnSpeedCoef;

    private float force;
    private float changeTurnSpeed;

    void Start()
    {
        changeTurnSpeed = speed * changeTurnSpeedCoef;
        force = 1;
        FindingObjects.instance.findingObj.Add(gameObject);
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
            leftEngineRigidbody.AddRelativeForce(Vector3.up * speed * changeTurnSpeed);
        }
        else if (horizontal < 0)
        {
            rightEngineRigidbody.AddRelativeForce(Vector3.up * speed * changeTurnSpeed);
        }
        if (vertical > 0)
        {
            leftEngineRigidbody.AddRelativeForce(Vector3.up * speed * force);
            rightEngineRigidbody.AddRelativeForce(Vector3.up * speed * force);
        }
        else if (vertical < 0)
        {
            leftEngineRigidbody.AddRelativeForce(Vector3.up * -speed * force);
            rightEngineRigidbody.AddRelativeForce(Vector3.up * -speed * force);
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
            force = 4f;
            Effects.instance.UseForce();
        }
        else
        {
            force = 2f;
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
