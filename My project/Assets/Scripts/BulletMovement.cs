using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 40f;

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}