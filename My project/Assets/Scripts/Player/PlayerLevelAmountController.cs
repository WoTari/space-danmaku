using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelAmountController : MonoBehaviour
{
    private Animator anim;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerController.level != playerController.levelMax)
        {
            anim.SetBool("isMaxLevel", false);
        }

        else
        {
            anim.SetBool("isMaxLevel", true);
        }
    }
}
