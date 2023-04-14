using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PowerController : MonoBehaviour
{
    public GameObject powerSmall;
    public GameObject powerLarge;

    // Small Power Variables
    public float smallPowerAmount = 1.00f;
    public int smallPowerSpeed = 15;
    public bool canSpawnSmallPower = false;
    public float smallPowerXPosition;
    public bool canGetRandomSmallPowerPos;

    // Large Power variables
    public int largePowerAmount = 10;
    public int largePowerSpeed = 27;
    public bool canSpawnLargePower = false;
    public float largePowerXPosition;
    public bool canGetRandomLargePowerPos;

    private void Start()
    {
        StartCoroutine(SmallPowerCooldown());
        StartCoroutine(LargePowerCooldown());
    }
    void Update()
    {
        PowerSmall();
        PowerLarge();
        LargePowerRandomPos();
        SmallPowerRandomPos();
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

    // Delay for the small power box spawns
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

    // Delay for the large power box spawns
    IEnumerator LargePowerCooldown()
    {
        yield return new WaitForSeconds(largePowerSpeed);
        canSpawnLargePower = true;
    }

    IEnumerator LargePowerRandomPosCooldown()
    {
        yield return new WaitForSeconds(largePowerSpeed);
        canGetRandomLargePowerPos = true;
    }

    IEnumerator SmallPowerRandomPosCooldown()
    {
        yield return new WaitForSeconds(smallPowerSpeed);
        canGetRandomSmallPowerPos = true;
    }

    public void LargePowerRandomPos()
    {
        largePowerXPosition = Random.Range(-10f, 10f);
        canGetRandomLargePowerPos = false;
        StartCoroutine(LargePowerRandomPosCooldown());
    }

    public void SmallPowerRandomPos()
    {
        smallPowerXPosition = Random.Range(-10f, 10f);
        canGetRandomSmallPowerPos = false;
        StartCoroutine(SmallPowerRandomPosCooldown());
    }
}
