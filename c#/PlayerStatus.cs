using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public StaminaBar staminaBar;

    public float maxHealth = 200;
    public float maxStamina = 100;
    public float currentHealth;
    public float currentStamina;
    public float staminaRegenRate = 17f;
    // Start is called before the first frame update
    void Start()
    {
        staminaBar.SetMaxStamina(maxStamina);
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        staminaBar.UpdateStamina(currentStamina);

        if (currentStamina >= maxStamina)
        {
            currentStamina = maxStamina;
        }

        regenStamina();
        }

    public void regenStamina()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            currentStamina += staminaRegenRate * Time.fixedDeltaTime;
        }
        else
        {
            currentStamina += staminaRegenRate * 2 * Time.fixedDeltaTime;
        }
    }
}
