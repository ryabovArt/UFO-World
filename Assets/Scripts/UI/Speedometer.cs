using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private float minValueArrowAngle;
    [SerializeField] private float maxValueArrowAngle;

    [SerializeField] private RectTransform arrow;

    [SerializeField] private float speed;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            arrow.localEulerAngles =
            new Vector3(0, 0, Mathf.MoveTowards(arrow.localEulerAngles.z, 0, speed * Time.deltaTime));
        }
        else if (horizontal < 0)
        {
            arrow.localEulerAngles =
            new Vector3(0, 0, Mathf.MoveTowards(arrow.localEulerAngles.z, minValueArrowAngle, speed * Time.deltaTime));
        }
        else if (horizontal == 0) arrow.localEulerAngles = new Vector3(0, 0, Mathf.MoveTowards(arrow.localEulerAngles.z, 90, speed * Time.deltaTime));

    }
}
