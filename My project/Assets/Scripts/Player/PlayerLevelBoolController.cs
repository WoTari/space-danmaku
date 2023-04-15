using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;

public class PlayerLevelBoolController : MonoBehaviour
{
    private Animator anim;
    private PlayerController playerController;

    void Start()
    {
        anim = GetComponent<Animator>();
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        if (playerController.level == playerController.levelMax)
        {
            anim.SetBool("isMaxLevel", true);
        }

        else if (playerController.power >= playerController.powerForLevelUp && playerController.level != playerController.levelMax)
        {
            anim.SetBool("CanLevelUp", true);
            anim.SetBool("isMaxLevel", false);
        }

        else
        {
            anim.SetBool("CanLevelUp", false);
            anim.SetBool("isMaxLevel", false);
        }

        
    }
}
