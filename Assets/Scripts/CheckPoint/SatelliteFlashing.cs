using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteFlashing : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    [SerializeField] [Range(0, 2f)] private float changeColorSpeed;
    private MeshRenderer satelliteMeshRenderer;

    private int colorIndex;
    private float t;

    void Start()
    {
        satelliteMeshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        ChangeColor();
    }

    /// <summary>
    /// Смена цвета
    /// </summary>
    private void ChangeColor()
    {
        satelliteMeshRenderer.material.color = Color.Lerp(satelliteMeshRenderer.material.color, colors[colorIndex], changeColorSpeed * Time.deltaTime);

        t = Mathf.Lerp(t, 1f, changeColorSpeed * Time.deltaTime);
        if (t > 0.9f)
        {
            t = 0;
            colorIndex++;
            colorIndex = (colorIndex >= colors.Length) ? 0 : colorIndex;
        }
    }
}
