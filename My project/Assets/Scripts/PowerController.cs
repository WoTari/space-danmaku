using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PowerController : MonoBehaviour
{
    public GameObject powerSmall;
    public GameObject powerLarge;

    public float destroyPowerAt = 57f;

    public float smallPowerAmount = 1.00f;
    public int smallPowerSpeed = 15;
    public bool canSpawnSmallPower = false;

    public int largePowerAmount = 10;
    public int largePowerSpeed = 27;
    public bool canSpawnLargePower = false;
    public float largePowerMovementSpeed = 0.09f;

    private void Start()
    {
        StartCoroutine(SmallPowerCooldown());
        StartCoroutine(LargePowerCooldown());
    }
    void Update()
    {
        PowerSmall();
        PowerLarge();
    }

    // Small Power
    private void PowerSmall()
    {
        if (canSpawnSmallPower)
        {
            var position = new Vector2(Random.Range(-132, 95), 170);
            Instantiate(powerSmall, position, powerSmall.transform.rotation);
            canSpawnSmallPower = false;
            StartCoroutine(SmallPowerCooldown());
        }
    }
    IEnumerator SmallPowerCooldown()
    {
        yield return new WaitForSeconds(smallPowerSpeed);
        canSpawnSmallPower = true;
    }

    // Large Power
    private void PowerLarge()
    {
        if (canSpawnLargePower)
        {
            var position = new Vector2(Random.Range(-132, 95), 170);
            Instantiate(powerLarge, position, powerLarge.transform.rotation);
            canSpawnLargePower = false;
            StartCoroutine(LargePowerCooldown());
        }
    }
    IEnumerator LargePowerCooldown()
    {
        yield return new WaitForSeconds(largePowerSpeed);
        canSpawnLargePower = true;
    }

}
