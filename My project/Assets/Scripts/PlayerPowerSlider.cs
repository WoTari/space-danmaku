using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPowerSlider : MonoBehaviour
{
    public Slider slider;
    public PlayerController power;

    public void SetPower(float power)
    {
        slider.value = power;
    }

    private void Update()
    {
        slider.maxValue = power.powerForLevelUp;
    }
}
