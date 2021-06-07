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

        float currentRotation = arrow.localEulerAngles.z;

        if (horizontal > 0)
        {
            arrow.localEulerAngles =
            new Vector3(0, 0, Mathf.Lerp(maxValueArrowAngle, currentRotation, speed * Time.deltaTime));
            print("currentRotation " + horizontal);
        }
        else if (horizontal < 0)
        {
            arrow.localEulerAngles =
            new Vector3(0, 0, Mathf.Lerp(minValueArrowAngle, currentRotation, speed * Time.deltaTime));
        }
        else if (horizontal == 0) arrow.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(0, currentRotation, speed * Time.deltaTime));
        
    }
}
