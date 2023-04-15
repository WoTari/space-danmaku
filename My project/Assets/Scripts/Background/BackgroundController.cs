using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private RawImage image;
    public float speed = 0.001f;

    void Update()
    {
        if (image.gameObject.tag == "Repeating Image")
        {
            image.uvRect = new Rect(image.uvRect.position + new Vector2(0.2f, 1f) * speed, image.uvRect.size);
        }

        else
        {
            image.uvRect = new Rect(image.uvRect.position + Vector2.up * speed, image.uvRect.size);
        }
    }
}
