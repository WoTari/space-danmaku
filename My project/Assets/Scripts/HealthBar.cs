using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Boss1Controller bossHp;

    public void SetMaxHp(float hp)
    {
        slider.value = hp;
    }

    private void Update()
    {
        slider.maxValue = bossHp.maxHp;
    }
}
