using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    public Gradient Gradient;
    public Image Fill;

    public void SetMaxStamina(float stamina)
    {
        staminaBar.maxValue = stamina;
        staminaBar.value = stamina;
        Fill.color = Gradient.Evaluate(1f);
    }

    public void UpdateStamina(float stamina)
    {
        staminaBar.value = stamina;

        Fill.color = Gradient.Evaluate(staminaBar.normalizedValue);
    }

}
