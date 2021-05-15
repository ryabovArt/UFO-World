using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationGIFSprites : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image image;

    void Update()
    {
        image.sprite = sprites[(int)(Time.time * 10) % sprites.Length];
    }
}
