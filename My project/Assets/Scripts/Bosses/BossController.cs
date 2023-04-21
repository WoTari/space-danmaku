using System.Runtime.CompilerServices;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float maxHp = 1000;
    public float currentHp = 1000;
    private int waypoint = 0;
    public HealthBar hpBar;
    public BossTimer timer;
    private PlayerController playerController;
    private HitEffect hitEffect;

    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        hitEffect = GetComponent<HitEffect>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Takes hp away from enemy if player hits them with a bullet
        if (collider.gameObject.tag == "PlayerProjectile")
        {
            currentHp -= playerController.bulletDamage;
            hpBar.SetMaxHp(currentHp);
            hitEffect.Flash();
        }

        else if (collider.gameObject.tag == "PlayerHomingProjectile")
        {
            currentHp -= playerController.homingBulletDamage;
            hpBar.SetMaxHp(currentHp);
            hitEffect.Flash();
        }

        // Takes hp away from enemy if player hits them with a bomb
        else if (collider.gameObject.tag == "PlayerBomb")
        {
            currentHp -= playerController.bombDamage;
            hpBar.SetMaxHp(currentHp);
        }
    }

    void Update()
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
