using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    [SerializeField] private float topBorder;
    [SerializeField] private float bottomBorder;
    public float rightBorder;
    public float leftBorder;

    void Start()
    {
        transform.position = new Vector3()
        {
            x = transform.position.x,
            y = transform.position.y,
            z = transform.position.z
        };
    }

    void Update()
    {
        SetCameraPosition();
    }

    /// <summary>
    /// Обновляем позицию камеры
    /// </summary>
    private void SetCameraPosition()
    {
        if (player)
        {
            Vector3 target = new Vector3()
            {
                x = player.transform.position.x,
                y = player.transform.position.y + bottomBorder,
                z = transform.position.z
            };

            Vector3 pos = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
            transform.position = pos;
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, bottomBorder, topBorder),
            transform.position.z
            );
    }    

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(new Vector2(leftBorder, topBorder), new Vector2(rightBorder, topBorder));
    //}
}
