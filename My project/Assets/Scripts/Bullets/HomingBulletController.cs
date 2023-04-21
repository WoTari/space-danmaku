using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HomingBulletController : MonoBehaviour
{
    public GameObject targetObject;
    public float speed = 10;
    public float maxSpeed = 20;
    public float acceleration = 1;
    public float turnSpeedDegrees = 15;
    public float yRange = 110f;

    Vector3 direction;
    Vector3 velocity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && gameObject.tag == "PlayerHomingProjectile")
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector3 startDirection, Vector3 startVelocity, GameObject target)
    {
        direction = startDirection;
        velocity = startVelocity;
        this.targetObject = target;
    }

    void Update()
    {
        // Find direction to target
        Vector3 toTarget = targetObject.transform.position - transform.position;
        toTarget.Normalize();

        float angleToTarget = Vector3.Angle(direction, toTarget);

        Vector3 right = Vector3.Cross(direction, Vector3.forward);
        float dot = Vector3.Dot(direction, right);
        float sign = Mathf.Sign(dot);
        float signedAngleToTarget = angleToTarget * sign;

        // The smaller the angle, the bigger the frame speed
        float frameSpeed = Mathf.Clamp(1.0f - (angleToTarget / 180.0f), 0.0f, 1.0f);
        frameSpeed *= frameSpeed;

        // Change with turn speed, keep both vectors normalized
        float turnRadians = Mathf.Deg2Rad * turnSpeedDegrees * Time.deltaTime;
        direction = Vector3.RotateTowards(direction, toTarget, turnRadians, 0.0f);

        // Accelerate to direction, modifying velocity
        velocity = velocity + direction * acceleration * Time.deltaTime;

        // Cap velocity
        float velocityMagnitude = velocity.magnitude;
        if (velocityMagnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }

        // Move by applying velocity to position
        transform.position = transform.position + velocity * frameSpeed * Time.deltaTime;

        // Bullet gets destroyed when ít goes past the boundaries of the game
        if (transform.position.y >= yRange)
        {
            Destroy(gameObject);
        }
    }
}
