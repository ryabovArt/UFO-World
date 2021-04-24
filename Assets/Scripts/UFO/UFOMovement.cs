using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovement : MonoBehaviour
{
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
        FindingObjects.instance.findingObj.Add(this.gameObject);
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

        if (horizontal > 0)
        {
            leftEngineRigidbody.AddRelativeForce(Vector3.up * speed * changeTurnSpeed);
        }
        else if (horizontal < 0)
        {
            rightEngineRigidbody.AddRelativeForce(Vector3.up * speed * changeTurnSpeed);
        }
        else if (vertical > 0)
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
}
