using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerText : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] TMP_Text powerText;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        powerText.text = playerController.power.ToString("f0");
    }
}
