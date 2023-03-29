using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossTimer : MonoBehaviour
{
    [SerializeField] float startTime;
    public float currentTime;
    bool timerStarted = false;
    [SerializeField] TMP_Text timerText;
    
    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            timerStarted = true;
            timerText.text = currentTime.ToString();
        }

        if(timerStarted)
        {
            currentTime -= Time.deltaTime;
        }
        if(currentTime <= 0)
        {
            timerStarted = false;
            currentTime = 0;
        }

        timerText.text = currentTime.ToString("f2");
    }
}
