using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerLevelTextController : MonoBehaviour
{
    private Animator anim;
    private PlayerController playerController;
    public float FadeDuration = 1f;
    public Color Color1 = Color.gray;
    public Color Color2 = Color.white;

    private Color startColor;
    private Color endColor;
    private float lastColorChangeTime;

    public Material material;

    void Start()
    {
        anim = GetComponent<Animator>();
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        material = GetComponent<Renderer>().material;
        startColor = Color1;
        endColor = Color2;
    }

    void FixedUpdate()
    {
        if (playerController.power >= playerController.powerForLevelUp)
        {
            anim.SetBool("CanLevelUp", true);
        }

        else
        {
            anim.SetBool("CanLevelUp", false);
        }
    }

    private void Update()
    {
        var ratio = (Time.time - lastColorChangeTime) / FadeDuration;
        ratio = Mathf.Clamp01(ratio);
        material.color = Color.Lerp(startColor, endColor, ratio);
        material.color = Color.Lerp(startColor, endColor, Mathf.Sqrt(ratio)); 

        if (ratio == 1f)
        {
            lastColorChangeTime = Time.time;

            // Switch colors
            var temp = startColor;
            startColor = endColor;
            endColor = temp;
        }
    }
}
