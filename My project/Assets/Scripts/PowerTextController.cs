using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerTextController : MonoBehaviour
{
    public PlayerController playerController;
    [SerializeField] TMP_Text powerText;

    private void Start()
    {
        PlayerController playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        
    }
}
