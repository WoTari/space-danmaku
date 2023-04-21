using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ShootingStarController : MonoBehaviour
{
    // other
    public GameObject shootingStar;
    public float spawnTime;
    public bool canSpawn;
    public float shootingStarSpeed;
    public float getDestroyedAtX;

    // Variables for changing where the shooting star spawns
    public float _x;
    public float yMin;
    public float yMax;



    void Start()
    {
        StartCoroutine(ShootingStarCooldown());
    }

    void Update()
    {
        if (canSpawn) 
        {
            canSpawn = false;

            // Spawns the shooting star
            var spawnPos = new Vector2(_x, Random.Range(yMin, yMax));
            GameObject shootingStarObject = Instantiate(shootingStar, spawnPos, shootingStar.transform.rotation);

            // Scales the shooting star according to a random value
            shootingStarObject.transform.localScale = new Vector2(Random.Range(0.8f, 1.14f), (Random.Range(0.8f, 1.25f)));
            StartCoroutine(ShootingStarCooldown());
        }
    }

    private IEnumerator ShootingStarCooldown()
    {
        yield return new WaitForSeconds(spawnTime);
        canSpawn = true;
    }      
}
