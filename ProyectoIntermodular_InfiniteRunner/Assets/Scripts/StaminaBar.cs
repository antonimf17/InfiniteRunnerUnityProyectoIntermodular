using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaSlider;  // Referencia al Slider
    public float maxStamina = 100f;
   private float currentStamina;
    public float staminaRegenRate = 10f;
    public float staminaDrainRate = 20f;

    void Start()
    {
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = currentStamina;
    }

    void Update()
    {
        // Regeneración de estamina con el tiempo
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            staminaSlider.value = currentStamina;
        }
    }

    public void UseStamina(float amount)
    {
        currentStamina -= amount;
        if (currentStamina < 0) currentStamina = 0;
        staminaSlider.value = currentStamina;
    }

    public bool HasStamina()
    {
        return currentStamina > 0;
    }
    public float GetCurrentStamina()
    {
        return currentStamina;
    }
}