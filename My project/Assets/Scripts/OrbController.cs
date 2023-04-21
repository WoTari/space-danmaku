using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    private PlayerController playerController;
    public BulletController bulletController;
    public GameObject homingBulletPrefab;
    private Animator anim;
    private Animator anim2;
    private GameObject enemy;
    public int _x; // either 1 or -1

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        bulletController = GetComponent<BulletController>();
        enemy = GameObject.Find("Enemy");
        anim = GetComponent<Animator>();
        anim2 = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
    }
    public void ShootHomingBullet()
    {
        GameObject bullet = Instantiate(homingBulletPrefab, transform.position, Quaternion.identity);
        HomingBulletController bulletController1 = bullet.GetComponent<HomingBulletController>();

        // Launch bullet forward with initial velocity
        bulletController1.Launch(Vector3.up, new Vector3(_x, 0, 0) * 5.25f, enemy);  // Y-axis, towards the top of screen
    }

   void FixedUpdate()
   {
        if (playerController.level == 4)
        {
            anim.SetBool("Visible", true);
            anim2.SetBool("Visible", true);
        }
   }
}
