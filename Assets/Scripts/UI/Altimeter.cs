using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Altimeter : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private Slider altimeter;

    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;
    [SerializeField] private float sliderStep;

    void Start()
    {
        
    }

    void Update()
    {
        altimeter.value = player.transform.position.y;
        print(player.transform.position.y); 
    }
}
