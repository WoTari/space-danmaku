using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundController : MonoBehaviour
{
    public float speed = 0.02f;

    void Update()
    {
        // Move background
        transform.Translate(Vector2.down * speed);
    }
}
