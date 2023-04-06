using System.Runtime.CompilerServices;
using UnityEngine;

public class Boss1Controller : MonoBehaviour
{
    public float maxHp = 1000;
    public float currentHp = 1000;
    private int waypoint = 0;
    public HealthBar hpBar;
    public BossTimer timer;

    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;

    void OnTriggerEnter2D(Collider2D controller)
    {
        // Takes hp away from enemy if player hits them with a bullet
        if (controller.gameObject.tag == "PlayerProjectile")
        {
            BulletController c = controller.GetComponent<BulletController>();
            currentHp -= c.bulletDamage;
            hpBar.SetMaxHp(currentHp);
        }

        // Takes hp away from enemy if player hits them with a bomb
        else if (controller.gameObject.tag == "PlayerBomb")
        {
            BulletController b = controller.GetComponent<BulletController>();
            currentHp -= b.bombDamage;
            hpBar.SetMaxHp(currentHp);
        }
    }

    private void Update()
    {
        Move();
        Death();
    }

    // Method that makes the enemy move
    private void Move()
    {
        // If enemy reached the last waypoint then it stops
        if (waypoint <= waypoints.Length - 1)
        {

            // Move Enemy from current waypoint to the next one
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypoint].transform.position,
               moveSpeed * Time.deltaTime);

            // When enemy moves to the next waypoint, add 1 to the waypoint index
            if (transform.position.x == waypoints[waypoint].transform.position.x &&
                transform.position.y == waypoints[waypoint].transform.position.y)
            {
                waypoint += 1;
            }
        }
    }

    // Method kills enemy when hp reaches 0
    private void Death ()
    {
        if (currentHp <= 0 || timer.currentTime <= 0)
        {
            Destroy(gameObject);
            // here code for starting next phase of the boss yes ok good
        }
    }

}
