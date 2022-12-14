using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar: MonoBehaviour
{

    public Slider slider; //finds the slider located in the healthbar area
    public Gradient gradient; //gradient to show the healthbar's color
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health; //sets max value of healthbar
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
