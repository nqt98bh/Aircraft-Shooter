using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    bool isUpdateHealth;
    float targetHealth;
    float currentHealth;

    private void Update()
    {
        if (isUpdateHealth)
        {
            if(currentHealth > targetHealth)
            {
                currentHealth -= Time.deltaTime * 20;
                fill.color = gradient.Evaluate(slider.normalizedValue);
                slider.value = currentHealth;

            }
            else if (currentHealth < targetHealth)
            {
                currentHealth += Time.deltaTime * 20;
                fill.color = gradient.Evaluate(slider.normalizedValue);
                slider.value = currentHealth;
            }
            else
            {
                currentHealth = targetHealth;
                slider.value = currentHealth;

                isUpdateHealth = false;
                Debug.Log("isUpdateHealth" + isUpdateHealth);
                Debug.Log("Current health" + currentHealth);

            }
        }
    }

    public void SetMaxHealth(int health)
    {
            currentHealth = health;
            slider.maxValue = health;
            slider.value = health;
            fill.color = gradient.Evaluate(1f);
        Debug.Log("Current health" + currentHealth);
    }

    public void SetHealth(int health)
    {
            isUpdateHealth = true;
            targetHealth = health;
        Debug.Log("targetHealth" + targetHealth);
        Debug.Log("isUpdateHealth" + isUpdateHealth);

    }


}
