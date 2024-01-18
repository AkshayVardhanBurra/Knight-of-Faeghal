using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Health Bar imports
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Create a Singleton because why not idk why I am doing this other than to have a change to push
    public static HealthBar playerHealth;

    // Set health at start of game
    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    // Update health as game progresses
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(slider.value);
    }
}
